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

        private const int Key_Ctrl = 162;
        private const int Key_4 = 52;

        private static bool m_Flag_Key_Ctrl_Press = false;
        private static bool m_Flag_Key_4_Press = false;

        private static int s_vkCode = 0;
        private static LowLevelKeyboardProc s_proc = HookCallback;
        private static IntPtr s_hookID = IntPtr.Zero;

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
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                s_vkCode = Marshal.ReadInt32(lParam);

                if ((s_vkCode != Key_Ctrl) && (s_vkCode != Key_4))
                {
                    m_Flag_Key_4_Press = false;
                    m_Flag_Key_Ctrl_Press = false;
                }

                if (s_vkCode == Key_Ctrl)
                {
                    m_Flag_Key_Ctrl_Press = true;
                }

                if (s_vkCode == Key_4)
                {
                    m_Flag_Key_4_Press = true;
                }

                if (m_Flag_Key_4_Press && m_Flag_Key_Ctrl_Press)
                {
                    MakeScreenshot.Make_Full_Screenshot();
                    m_Flag_Key_4_Press = false;
                    m_Flag_Key_Ctrl_Press = false;
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
            s_hookID = SetHook(s_proc);
            Application.Run();
            UnhookWindowsHookEx(s_hookID);
        }
    }
}
