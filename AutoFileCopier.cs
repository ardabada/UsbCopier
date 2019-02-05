using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace UsbCopier
{
    public class AutoFileCopier
    {
        public AutoFileCopier(string[] searchWords, string saveLocation, string drive)
        {
            SearchWords = searchWords;
            Drive = drive;
            SaveLocation = saveLocation;
        }

        public readonly string SaveLocation;
        public readonly string[] SearchWords;
        public readonly string Drive;

        public bool Working { get; private set; } = false;
        public event EventHandler OnDone;

        public void ProcessDrive()
        {
            if (Working)
                return;
            var t = new Thread(() => _doDriveProcessing(Drive));
            t.Start();
        }

        void _doDriveProcessing(string drive)
        {
            Working = true;
            try
            {
                bool isDrive = false;
                foreach (var d in DriveInfo.GetDrives())
                {
                    if (d.IsReady && d.RootDirectory.FullName.ToLower() == drive.ToLower())
                    {
                        isDrive = true;
                        break;
                    }
                }
                if (isDrive)
                {
                    Logger.WriteLine("Starting autocopier for " + drive);
                    var files = listFiles(drive);
                    List<string> target = new List<string>();
                    foreach (var word in SearchWords)
                    {
                        target.AddRange(files.Where(x => x.ToLower().Contains(word.ToLower())));
                    }
                    target = target.Distinct().ToList();

                    Dictionary<string, string> results = new Dictionary<string, string>();

                    foreach (var file in target)
                    {
                        string newFile = copyFile(file);
                        if (string.IsNullOrEmpty(newFile) == false)
                            results.Add(file, newFile);
                    }
                    if (results.Count > 0)
                    {
                        string json = JsonConvert.SerializeObject(results, Formatting.Indented);
                        string reportPath = Path.Combine(SaveLocation, "_file_flags_" + Guid.NewGuid().ToString() + ".bin");
                        StreamWriter writer = new StreamWriter(reportPath);
                        writer.Write(json);
                        writer.Close();
                        Logger.WriteLine("Auto copier saved " + results.Count + " file" + (results.Count == 1 ? string.Empty : "s"));
                    }
                    else Logger.WriteLine("No files matching search words were found.");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Auto copier error:" + Environment.NewLine + ex.ToString());
            }
            finally
            {
                Working = false;
                OnDone?.Invoke(this, EventArgs.Empty);
            }
        }

        string copyFile(string file)
        {
            try
            {
                string newPath = Path.Combine(SaveLocation, Guid.NewGuid().ToString() + ".bin");
                FileStream inf = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileStream outf = new FileStream(newPath, FileMode.Create);
                int a;
                while ((a = inf.ReadByte()) != -1)
                {
                    outf.WriteByte((byte)a);
                }
                inf.Close();
                inf.Dispose();
                outf.Close();
                outf.Dispose();

                return newPath;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Unable to copy file " + file + Environment.NewLine + ex.ToString());
                return null;
            }
        }

        List<string> listFiles(string path)
        {
            try
            {
                List<string> result = new List<string>();

                result = filesInDirectory(path);

                return result;
            }
            catch { return new List<string>(); }
        }

        List<string> filesInDirectory(string dir)
        {
            List<string> result = new List<string>();
            try
            {
                DirectoryInfo d = new DirectoryInfo(dir);
                FileInfo[] files = d.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                    result.Add(file.FullName);
            }
            catch { }

            try
            {
                foreach (var s_dir in Directory.GetDirectories(dir))
                    result.AddRange(filesInDirectory(s_dir));
            }
            catch { }
            return result;
        }
    }
}
