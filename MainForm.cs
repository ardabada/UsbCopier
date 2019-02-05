using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Management;

namespace UsbCopier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            locationTextbox.Text = Program.BaseDirectory;
            loadSearchWords();
            initDeviceListener();
        }

        ManagementEventWatcher insertWatcher = null, removeWatcher = null;
        bool isWorking = false;
        List<string> selfCopyWorking = new List<string>();

        void initArrivalListener()
        {
            insertWatcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            insertWatcher.EventArrived += Watcher_DeviceArrived;
            insertWatcher.Query = query;
        }
        void initRemoveListener()
        {
            removeWatcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 3");
            removeWatcher.EventArrived += Watcher_DeviceRemoved;
            removeWatcher.Query = query;
        }
        void initDeviceListener()
        {
            initArrivalListener();
            initRemoveListener();
        }

        void Watcher_DeviceArrived(object sender, EventArrivedEventArgs e)
        {
            string drive = e.NewEvent.Properties["DriveName"].Value.ToString() + "\\";
            Logger.WriteLine("Inserted drive " + drive);
            startCopy(drive);
        }
        void Watcher_DeviceRemoved(object sender, EventArrivedEventArgs e)
        {
            string drive = e.NewEvent.Properties["DriveName"].Value.ToString() + "\\";
            Logger.WriteLine("Removed drive " + drive);
            startCopy(drive);
        }

        string[] SearchWords
        {
            get { return searchWordsInput.Lines; }
        }
        string SaveLocation
        {
            get { return locationTextbox.Text; }
        }

        bool startCopy(string path)
        {
            try
            {
                if (selfCopyWorking.Where(x => x.ToLower() == path.ToLower()).Any())
                    return false;

                if (!Directory.Exists(path))
                    return false;
                
                if (SearchWords != null && SearchWords.Length > 0)
                {
                    bool isDrive = false;
                    foreach (var d in DriveInfo.GetDrives())
                    {
                        if (d.IsReady && d.DriveType == DriveType.Removable && d.RootDirectory.FullName.ToLower() == path.ToLower())
                        {
                            isDrive = true;
                            break;
                        }
                    }
                    if (isDrive)
                    {
                        AutoFileCopier afc = new AutoFileCopier(SearchWords, SaveLocation, path);
                        afc.OnDone += (s, e) =>
                        {
                            Logger.WriteLine("Copier completed for " + path);
                        };
                        afc.ProcessDrive();
                    }
                }

                return true;
            }
            catch { return false; }
        }


        public string SearchWordsFile
        {
            get
            {
                string path = Path.Combine(Program.BaseDirectory, "words.lst");
                if (!File.Exists(path))
                    File.Create(path).Close();
                return path;
            }
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = locationTextbox.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                locationTextbox.Text = folderBrowserDialog.SelectedPath;
        }

        private void loadWordsBtn_Click(object sender, EventArgs e)
        {
            loadSearchWords();
        }
        private void saveWordsBtn_Click(object sender, EventArgs e)
        {
            saveSearchWords();
        }
        void loadSearchWords()
        {
            searchWordsInput.Lines = File.ReadAllLines(SearchWordsFile);
        }
        void saveSearchWords()
        {
            File.WriteAllLines(SearchWordsFile, searchWordsInput.Lines);
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            hideForm();
        }

        private void showLogBtn_Click(object sender, EventArgs e)
        {
            Process.Start("notepad", Logger.LogFile);
        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            if (checkSaveLocation())
                toggleStart();
            else MessageBox.Show("Please select valid folder as save location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        bool checkSaveLocation()
        {
            return Directory.Exists(locationTextbox.Text);
        }

        void toggleStart()
        {
            isWorking = !isWorking;
            if (isWorking)
            {
                blockUI();
                insertWatcher.Start();
            }
            else
            {
                unblockUI();
                insertWatcher.Stop();
            }
        }

        void blockUI()
        {
            locationTextbox.Enabled = browseBtn.Enabled = searchWordsInput.Enabled = saveWordsBtn.Enabled = loadWordsBtn.Enabled = false;
            startStopBtn.Text = "Stop";
        }
        void unblockUI()
        {
            locationTextbox.Enabled = browseBtn.Enabled = searchWordsInput.Enabled = saveWordsBtn.Enabled = loadWordsBtn.Enabled = true;
            startStopBtn.Text = "Start";
        }

        void hideForm()
        {
            Hide();
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3000);
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            showForm();
        }

        void showForm()
        {
            Show();
            notifyIcon.Visible = false;
        }
    }
}
