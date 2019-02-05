namespace UsbCopier
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.locationTextbox = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.searchWordsInput = new System.Windows.Forms.TextBox();
            this.loadWordsBtn = new System.Windows.Forms.Button();
            this.saveWordsBtn = new System.Windows.Forms.Button();
            this.startStopBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.showLogBtn = new System.Windows.Forms.Button();
            this.hideBtn = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save location:";
            // 
            // locationTextbox
            // 
            this.locationTextbox.Location = new System.Drawing.Point(101, 6);
            this.locationTextbox.Name = "locationTextbox";
            this.locationTextbox.Size = new System.Drawing.Size(290, 23);
            this.locationTextbox.TabIndex = 1;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(397, 5);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search words: (one per line)";
            // 
            // searchWordsInput
            // 
            this.searchWordsInput.Location = new System.Drawing.Point(15, 53);
            this.searchWordsInput.Multiline = true;
            this.searchWordsInput.Name = "searchWordsInput";
            this.searchWordsInput.Size = new System.Drawing.Size(457, 116);
            this.searchWordsInput.TabIndex = 4;
            // 
            // loadWordsBtn
            // 
            this.loadWordsBtn.Location = new System.Drawing.Point(397, 175);
            this.loadWordsBtn.Name = "loadWordsBtn";
            this.loadWordsBtn.Size = new System.Drawing.Size(75, 23);
            this.loadWordsBtn.TabIndex = 5;
            this.loadWordsBtn.Text = "Load";
            this.loadWordsBtn.UseVisualStyleBackColor = true;
            this.loadWordsBtn.Click += new System.EventHandler(this.loadWordsBtn_Click);
            // 
            // saveWordsBtn
            // 
            this.saveWordsBtn.Location = new System.Drawing.Point(316, 175);
            this.saveWordsBtn.Name = "saveWordsBtn";
            this.saveWordsBtn.Size = new System.Drawing.Size(75, 23);
            this.saveWordsBtn.TabIndex = 6;
            this.saveWordsBtn.Text = "Save";
            this.saveWordsBtn.UseVisualStyleBackColor = true;
            this.saveWordsBtn.Click += new System.EventHandler(this.saveWordsBtn_Click);
            // 
            // startStopBtn
            // 
            this.startStopBtn.Location = new System.Drawing.Point(15, 204);
            this.startStopBtn.Name = "startStopBtn";
            this.startStopBtn.Size = new System.Drawing.Size(457, 23);
            this.startStopBtn.TabIndex = 7;
            this.startStopBtn.Text = "Start";
            this.startStopBtn.UseVisualStyleBackColor = true;
            this.startStopBtn.Click += new System.EventHandler(this.startStopBtn_Click);
            // 
            // showLogBtn
            // 
            this.showLogBtn.Location = new System.Drawing.Point(15, 175);
            this.showLogBtn.Name = "showLogBtn";
            this.showLogBtn.Size = new System.Drawing.Size(75, 23);
            this.showLogBtn.TabIndex = 8;
            this.showLogBtn.Text = "Show log";
            this.showLogBtn.UseVisualStyleBackColor = true;
            this.showLogBtn.Click += new System.EventHandler(this.showLogBtn_Click);
            // 
            // hideBtn
            // 
            this.hideBtn.Location = new System.Drawing.Point(96, 175);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.Size = new System.Drawing.Size(75, 23);
            this.hideBtn.TabIndex = 9;
            this.hideBtn.Text = "Hide";
            this.hideBtn.UseVisualStyleBackColor = true;
            this.hideBtn.Click += new System.EventHandler(this.hideBtn_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Click here to open copier";
            this.notifyIcon.BalloonTipTitle = "Usb Copier";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Usb Copier";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 234);
            this.Controls.Add(this.hideBtn);
            this.Controls.Add(this.showLogBtn);
            this.Controls.Add(this.startStopBtn);
            this.Controls.Add(this.saveWordsBtn);
            this.Controls.Add(this.loadWordsBtn);
            this.Controls.Add(this.searchWordsInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.locationTextbox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usb Copier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox locationTextbox;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchWordsInput;
        private System.Windows.Forms.Button loadWordsBtn;
        private System.Windows.Forms.Button saveWordsBtn;
        private System.Windows.Forms.Button startStopBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button showLogBtn;
        private System.Windows.Forms.Button hideBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

