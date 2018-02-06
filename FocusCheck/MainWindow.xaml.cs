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
using System.Windows.Threading;

namespace FocusCheck
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KeyDown += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"Key pressed is {e.Key}");
            };

            LostFocus += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"Lost focus");
            };

            LostKeyboardFocus += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"Lost focus: old focus was {e.OldFocus} new focus is {e.NewFocus}");
            };

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += (s, e) =>
            {
                var kbdFocus = Keyboard.FocusedElement;
                System.Diagnostics.Debug.WriteLine($"{kbdFocus?.ToString() ?? "Nothing"} has the keyboard focus");
                System.Diagnostics.Debug.WriteLine($"Logical focus {this.IsFocused}");
            };
            timer.Start();

        }
    }
}
