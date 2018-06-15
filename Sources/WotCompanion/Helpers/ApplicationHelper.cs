using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotCompanion
{
    public static class ApplicationHelper
    {
        public static float DefaultFontSize => 8.25F;

        public static string DefaultFontName => "Segoe UI";

        static WeakReference wRef;
        public static MainForm MainForm
        {
            get => (wRef != null) ? wRef.Target as MainForm : null;
            set => wRef = new WeakReference(value);
        }
    }
}
