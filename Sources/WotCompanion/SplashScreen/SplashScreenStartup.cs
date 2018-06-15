using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotCompanion.Common;

namespace WotCompanion.SplashScreen
{
    class SplashScreenStartup : IObserver<string>
    {
        void IObserver<string>.OnCompleted()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false, 1500, ApplicationHelper.MainForm);
        }
        void IObserver<string>.OnNext(string status)
        {
            if (DevExpress.XtraSplashScreen.SplashScreenManager.Default == null)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultSplashScreen(ApplicationHelper.MainForm, true, true, ProjectInfo.ProjectName, status);
            }
            else
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.SetDefaultSplashScreenStatus(false, status);
            }
        }
        void IObserver<string>.OnError(Exception error) { throw error; }
    }
}
