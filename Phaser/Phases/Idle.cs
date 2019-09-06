using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Phaser.Phases
{
    class Idle : IPhase
    {
        private string Directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        

        public void WaitForEvents()
        {
            var drive = new DriveInfo("C");

            if (drive.IsReady)
            {
                if (drive.AvailableFreeSpace < Math.Pow(10, 10))
                {
                    PerformAction();
                }
            }

        }

        public void PerformAction()
        {
            File.WriteAllText(Directory + @"\hours.txt", DateTime.Now.AddHours(12).ToString());

            Timer timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            
        }
    }
}
