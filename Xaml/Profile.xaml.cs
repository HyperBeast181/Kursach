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
using System.Windows.Shapes;

namespace WpfApp1.Xaml
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Close the current tikets window
            this.Close();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void checkAllClientsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            tiketinfo tiketWindow = new tiketinfo();
            tiketWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tiketinfo tiketWindow = new tiketinfo();
            tiketWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tiketinfo tiketWindow = new tiketinfo();
            tiketWindow.Show();
        }
    }
}
