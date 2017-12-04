using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CaptureTool.WorkWithSystemFiles
{
    class MakeScreenshot
    {
        private static void Make_Screenshot(int offsetX, int offsetY, int widthArea, int heightArea, string pathToSave)
        {
            var bmp = new Bitmap(widthArea, heightArea);

            Graphics graph = Graphics.FromImage(bmp);
            graph.CopyFromScreen(offsetX, offsetY, 0, 0, bmp.Size);

            bmp.Save(pathToSave);
        }

        public static void Make_Full_Screenshot()
        {
            int screenNum = 1;

            foreach (Screen screen in Screen.AllScreens)
            {
                string pathToSave = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
                    + "\\" + "Screen_" + screenNum.ToString() + " " 
                    + DateTime.Now.ToString().Replace(':', '_') + ".bmp");
                ++screenNum;

                Make_Screenshot(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height, pathToSave);
            }
        }
    }
}
