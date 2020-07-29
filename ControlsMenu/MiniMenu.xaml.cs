using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlsMenu
{
    /// <summary>
    /// Logika interakcji dla klasy MiniMenu.xaml
    /// </summary>
    public partial class MiniMenu : Window
    {
        [DllImport("user32.dll")]
        static extern void ClipCursor(ref System.Drawing.Rectangle rect);

        [DllImport("user32.dll")]
        static extern void ClipCursor(IntPtr rect);
        public MiniMenu()
        {
            this.Left = Cursor.Position.X - 140;
            this.Top = Cursor.Position.Y - 140;
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(Cursor.Position.X - 70, Cursor.Position.Y - 70, Cursor.Position.X + 70, Cursor.Position.Y + 70);
            ClipCursor(ref r);
            InitializeComponent();
            MiniMenuWindow.Topmost = true;
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            ClipCursor(IntPtr.Zero);
            this.Hide();
        }
        private static class Cursor
        {
            internal struct POINT
            {
                public int X;
                public int Y;
            }

            [DllImport("user32.dll")]
            static extern bool GetCursorPos(out POINT lpPoint);

            [DllImport("user32.dll")]
            static extern bool SetCursorPos(int X, int Y);

            public static POINT Position
            {
                get
                {
                    GetCursorPos(out POINT point);
                    return point;
                }
                set
                {
                    SetCursorPos(value.X, value.Y);
                }
            }
        }      
    }
}

