using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WotCompanion.Framework.Forms;

namespace WotCompanion.Framework
{
    public static class DataDirectoryHelper
    {
        public static IDisposable SingleInstanceApplicationGuard(string applicationName, out bool exit)
        {
            Mutex mutex = new Mutex(true, applicationName);
            if (mutex.WaitOne(0, false))
            {
                exit = false;
            }
            else
            {
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id && process.MainWindowHandle != IntPtr.Zero)
                    {
                        NativeMethods.SetForegroundWindow(process.MainWindowHandle);
                        NativeMethods.RestoreWindowAsync(process.MainWindowHandle);
                        break;
                    }
                }
                exit = true;
            }
            return mutex;
        }
    }
}
