using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CaptureTool
{
    public partial class Preferences_Window : Form
    {
        public static void StartPreferencesForm()
        {
            Initilization.Initilization.InitForm();

            Thread readKeyThread = new Thread(ReadKeyThread.ReadKeys);
            readKeyThread.Start();

            Application.Run(new Preferences_Window());

            readKeyThread.Abort();
        }

        public Preferences_Window()
        {
            InitializeComponent();

            WorkWithSystemFiles.Events.newKey += changeHotKeysText;
            WorkWithSystemFiles.Events.deactivateEditMode += deactivateEditMode;
        }

        private void Preferences_Window_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                trayIcon.Visible = true;
            }
        }

        private void Preferences_Window_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            WorkWithSystemFiles.Events.ClosePreferencesWindow(EventArgs.Empty);
        }

        private void changeHotKeysText(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() => HotKeyFullScreenshot.Text = PressedKeys.CurrentPressedKeys()));
        }

        private void deactivateEditMode(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() => flagEditMode.Text = ""));
        }

        private void EditHotKeyFullScreenMode_Click(object sender, EventArgs e)
        {
            flagEditMode.Text = "Edit Mode is ON";

            WorkWithSystemFiles.Events.ActiveEditMode(EventArgs.Empty);
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
