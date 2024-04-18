using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using WpfApp1.Xaml;
using System.Configuration;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void WrapPanel_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }

        private void accountBtn_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the tikets window
            Profile profilewindow = new Profile();

            // Show the tikets window
            profilewindow.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the tikets window
            tikets tiketsWindow = new tikets();

            // Show the tikets window
            tiketsWindow.Show();
        }
    }
}
