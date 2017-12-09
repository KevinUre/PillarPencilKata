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

namespace PencilApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pencil pencil = new Pencil(100,10);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WriteButton_Click(object sender, RoutedEventArgs e)
        {
            string tempString = PaperTextBox.Text;
            pencil.Write(PencilTextBox.Text, ref tempString);
            PaperTextBox.Text = tempString;
            PencilTextBox.Text = "";
        }
    }
}
