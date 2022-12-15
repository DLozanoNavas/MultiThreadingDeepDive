using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadAffinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Factory.StartNew(ChangeText);
        }

        void ChangeText()
        {
            Thread.Sleep(1000);
            UpdateText("Fenix Alliance inc.");
        }
        void UpdateText(string text)
        {
            //txtBox.Text = text; // This will raise an exception because the UI thread owns the UI element.
            Dispatcher.Invoke(() => { txtBox.Text = text; }); // This will work because the UI thread owns the UI element.
        }
    }
}
