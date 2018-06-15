using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Taskbar;
using WotCompanion.Common;
using WotCompanion.Framework;
using WotCompanion.Framework.Utils;
using WotCompanion.SplashScreen;

namespace WotCompanion
{
    static class Program
    {
        const string ForceDirectXPainter = "/directx";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TaskbarAssistant.Default.Initialize();

            using (DataDirectoryHelper.SingleInstanceApplicationGuard(ProjectInfo.MutexName, out bool exit))
            {
                if (exit)
                    return;
                foreach (var arg in Environment.GetCommandLineArgs())
                {
                    if (arg.Equals(ForceDirectXPainter, StringComparison.OrdinalIgnoreCase))
                        DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();
                }
                DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
                DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2016 Colorful");
                DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
                DevExpress.Utils.AppearanceObject.DefaultFont = new Font(ApplicationHelper.DefaultFontName, ApplicationHelper.DefaultFontSize);
                DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = DevExpress.XtraEditors.ScrollUIMode.Touch;
                DevExpress.XtraEditors.WindowsFormsSettings.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.OwnerControl;
                DevExpress.XtraEditors.WindowsFormsSettings.ColumnFilterPopupMode = DevExpress.XtraEditors.ColumnFilterPopupMode.Excel;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (new StartUpProcess())
                {
                    using (StartUpProcess.Status.Subscribe(new SplashScreenStartup()))
                    {
                        Application.Run(new MainForm());
                    }
                }
            }
        }
    }
}
