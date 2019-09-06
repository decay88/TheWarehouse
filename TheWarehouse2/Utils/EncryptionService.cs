using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheWarehouse.Algorithm;
using TheWarehouse.Config;

namespace TheWarehouse.Utils
{
    class EncryptionService
    {
        public static void Encrypt()
        {
            try
            {
                var files = Configuration.Instance.GetAllFiles();

                foreach (var file in files)
                {
                    try
                    {
                        AES.EncryptFile(file, Configuration.Instance.SymmetricalKey);
                    }
                    catch (Exception e) { MessageBox.Show(e.Message); }
                }

            }
            catch (Exception e)
            {

            }
        }

        public static void Decrypt()
        {
            try
            {
                var files = Configuration.Instance.GetAllFiles();

                foreach (var file in files)
                {
                    try
                    {
                        AES.DecryptFile(file, Configuration.Instance.SymmetricalKey);
                        MessageBox.Show("gottem " + Configuration.Instance.SymmetricalKey);

                    }
                    catch (Exception e) { }
                }

                if (File.Exists(Configuration.Instance.KeysFile)) File.Delete(Configuration.Instance.KeysFile);
                if (File.Exists(Configuration.Instance.EncFile)) File.Delete(Configuration.Instance.EncFile);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
