using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CaptureTool
{
    class MakeScreenshot
    {
        private static void Make_Screenshot(int offsetX, int offsetY, int widthArea, int heightArea, string pathToSave)
        {
            Graphics graph = null;

            var bmp = new Bitmap(widthArea, heightArea);

            graph = Graphics.FromImage(bmp);

            graph.CopyFromScreen(offsetX, offsetY, 0, 0, bmp.Size);

            bmp.Save(pathToSave);
        }

        public static void Make_Full_Screenshot()
        {

            int countScreen = 1;

            foreach (Screen screen in Screen.AllScreens)
            {
                string pathToSave = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
                    + "\\" + "Screen_" + countScreen.ToString() + " " 
                    + DateTime.Now.ToString().Replace(':', '_') + ".bmp");
                ++countScreen;

                Make_Screenshot(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height, pathToSave);
            }
        }
    }
}
