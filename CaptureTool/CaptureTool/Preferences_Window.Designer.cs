namespace CaptureTool
{
    partial class Preferences_Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences_Window));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HotKeyFullScreenshot = new System.Windows.Forms.Label();
            this.EditHotKeyFullScreenMode = new System.Windows.Forms.Button();
            this.flagEditMode = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Capture Tool";
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 226);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(197, 226);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(75, 23);
            this.quit.TabIndex = 1;
            this.quit.Text = "Quit";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HotKeyFullScreenshot);
            this.groupBox1.Controls.Add(this.EditHotKeyFullScreenMode);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 42);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hot-Key for Screenshot Full Screen";
            // 
            // HotKeyFullScreenshot
            // 
            this.HotKeyFullScreenshot.AutoSize = true;
            this.HotKeyFullScreenshot.Location = new System.Drawing.Point(6, 19);
            this.HotKeyFullScreenshot.Name = "HotKeyFullScreenshot";
            this.HotKeyFullScreenshot.Size = new System.Drawing.Size(0, 13);
            this.HotKeyFullScreenshot.TabIndex = 1;
            this.HotKeyFullScreenshot.Text = PressedKeys.DefaultPressedKeys();
            // EditHotKeyFullScreenMode
            // 
            this.EditHotKeyFullScreenMode.Location = new System.Drawing.Point(179, 14);
            this.EditHotKeyFullScreenMode.Name = "EditHotKeyFullScreenMode";
            this.EditHotKeyFullScreenMode.Size = new System.Drawing.Size(75, 23);
            this.EditHotKeyFullScreenMode.TabIndex = 0;
            this.EditHotKeyFullScreenMode.Text = "Edit";
            this.EditHotKeyFullScreenMode.UseVisualStyleBackColor = true;
            this.EditHotKeyFullScreenMode.Click += new System.EventHandler(this.EditHotKeyFullScreenMode_Click);
            // 
            // flagEditMode
            // 
            this.flagEditMode.AutoSize = true;
            this.flagEditMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flagEditMode.ForeColor = System.Drawing.Color.Red;
            this.flagEditMode.Location = new System.Drawing.Point(93, 231);
            this.flagEditMode.Name = "flagEditMode";
            this.flagEditMode.Size = new System.Drawing.Size(0, 12);
            this.flagEditMode.TabIndex = 5;
            // 
            // Preferences_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.flagEditMode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Preferences_Window";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Preferences_Window_Load);
            this.Resize += new System.EventHandler(this.Preferences_Window_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label HotKeyFullScreenshot;
        private System.Windows.Forms.Button EditHotKeyFullScreenMode;
        private System.Windows.Forms.Label flagEditMode;
    }
}

