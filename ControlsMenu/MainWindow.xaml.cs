using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlsMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KeyboardListener KListener = new KeyboardListener();
        MiniMenu mini;
        public Key MiniMenuKey { get; set; } = Key.B;
        public MainWindow()
        {
            KListener.KeyDown += new RawKeyEventHandler(KListener_KeyDown);
            InitializeComponent();
        }
        void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {

            if (args.Key == MiniMenuKey && (mini == null || mini.Visibility != Visibility.Visible))
            {
                mini = new MiniMenu();
                Mouse.OverrideCursor = Cursors.Cross;
                mini.Show();

            }
        }

        void KListener_KeyUp(object sender, RawKeyEventArgs args)
        {
            if (args.Key == Key.V && mini.Visibility == Visibility.Hidden)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                mini.Hide();
            }
        }
    }
}
