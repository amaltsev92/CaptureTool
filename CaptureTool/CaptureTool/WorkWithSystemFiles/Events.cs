using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureTool.WorkWithSystemFiles
{
    class Events
    {
        public static void CheckNewKeys(EventArgs e)
        {
            EventHandler handler = newKey;
            if (handler != null)
            {
                handler(newKey, e);
            }
        }

        public static void ActiveEditMode(EventArgs e)
        {
            EventHandler handler = activateEditMode;
            if (handler != null)
            {
                handler(activateEditMode, e);
            }
        }

        public static void DeactiveEditMode(EventArgs e)
        {
            EventHandler handler = deactivateEditMode;
            if (handler != null)
            {
                handler(deactivateEditMode, e);
            }
        }

        public static void ClosePreferencesWindow(EventArgs e)
        {
            EventHandler handler = closePreferencesWindow;
            if (handler != null)
            {
                handler(closePreferencesWindow, e);
            }
        }

        public static event EventHandler newKey;
        public static event EventHandler activateEditMode;
        public static event EventHandler deactivateEditMode;
        public static event EventHandler closePreferencesWindow;
    }
}
