using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1.Xaml
{
    /// <summary>
    /// Логика взаимодействия для tikets.xaml
    /// </summary>
    public partial class tikets : Window
    {
        public tikets()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

        private void accountBtn_Click(object sender, RoutedEventArgs e)
        {
            // Close the current tikets window
            this.Close();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the tikets window
            buy1 buywindow = new buy1();

            // Show the tikets window
            buywindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create an instance of the tikets window
            buy1 buywindow = new buy1();

            // Show the tikets window
            buywindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Create an instance of the tikets window
            buy1 buywindow = new buy1();

            // Show the tikets window
            buywindow.Show();
        }
    }
}
