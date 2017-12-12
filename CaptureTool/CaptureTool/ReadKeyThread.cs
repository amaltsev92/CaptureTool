using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace CaptureTool
{
    class ReadKeyThread
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private static bool flag_Activate_EditMode;

        private static int s_vkCode;
        private static LowLevelKeyboardProc s_proc;
        private static IntPtr s_hookID;

        static ReadKeyThread()
        {
            flag_Activate_EditMode = false;

            s_vkCode = 0;
            s_proc = HookCallback;
            s_hookID = IntPtr.Zero;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int iKey = wParam.ToInt32();
                s_vkCode = Marshal.ReadInt32(lParam);

                switch (iKey)
                {
                    case WM_KEYDOWN:
                        PressedKeys.SavePressedKey(s_vkCode);

                        if (flag_Activate_EditMode == false)
                        {
                            PressedKeys.CheckPressedKeys();
                        }
                        else
                        {
                            WorkWithSystemFiles.Events.CheckNewKeys(EventArgs.Empty);
                        }
                        break;

                    case WM_KEYUP:
                        if (flag_Activate_EditMode == false)
                        {
                            PressedKeys.DeletePressedKey(s_vkCode);
                        }
                        else
                        {
                            PressedKeys.SaveNewHotKeys();
                            WorkWithSystemFiles.Events.CheckNewKeys(EventArgs.Empty);
                            PressedKeys.DeletePressedKey(s_vkCode);

                            WorkWithSystemFiles.Events.DeactiveEditMode(EventArgs.Empty);

                            flag_Activate_EditMode = false;
                        }
                        break;

                    default:
                        break;
                }
            }
            return CallNextHookEx(s_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public static void ReadKeys()
        {
            WorkWithSystemFiles.Events.activateEditMode += activateEditMode;
            WorkWithSystemFiles.Events.closePreferencesWindow += deactivateEditMode;

            s_hookID = SetHook(s_proc);
            Application.Run();
            UnhookWindowsHookEx(s_hookID);
        }

        private static void activateEditMode(object sender, EventArgs e)
        {
            flag_Activate_EditMode = true;
        }

        private static void deactivateEditMode(object sender, EventArgs e)
        {
            flag_Activate_EditMode = false;
        }

    }
}
