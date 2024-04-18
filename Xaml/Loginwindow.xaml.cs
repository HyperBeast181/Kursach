using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using WpfApp1;

namespace WpfApp1.Xaml
{

    public class DatabaseAccess1
    {
        private readonly string connectionString;

        public DatabaseAccess1()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AirlineTicketingDBConnectionString"].ConnectionString;
        }

        //Создание  нового пользователя
        public bool AddUser(string username, string password, string role)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        //Проверки пользователя с заданным логином и паролем
        public bool ValidateUser(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    var result = (int)command.ExecuteScalar();
                    return result > 0;
                }
            }
        }

        //Роли авторизованного пользователя
        public string GetUserRole(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }


    }



    public partial class Loginwindow : Window
    {
        public Loginwindow()
        {
            InitializeComponent();
            InitializeMaterialDesign();
        }

        private void InitializeMaterialDesign()
        {
            // Create dummy objects to force the MaterialDesign assemblies to be loaded
            // from this assembly, which causes the MaterialDesign assemblies to be searched
            // relative to this assembly's path. Otherwise, the MaterialDesign assemblies
            // are searched relative to Eclipse's path, so they're not found.
            var card = new Card();
            var hue = new Hue("Dummy", Colors.Black, Colors.White);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPassword.Password;

            var dbAccess = new DatabaseAccess1();
            string role = dbAccess.GetUserRole(username, password);

            if (role != null)
            {

                this.Hide();
                if (role == "Sotrudnik")
                {
                    var employeeDashboard = new sotrudnick();
                    employeeDashboard.ShowDialog();
                }
                else if (role == "User")
                {
                    var userDashboard = new MainWindow();
                    userDashboard.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPassword.Password;

            var dbAccess = new DatabaseAccess1();
            if (dbAccess.AddUser(username, password, "User"))
            {
                MessageBox.Show("Пользователь успешно создан.");
            }
            else
            {
                MessageBox.Show("Не удалось создать пользователя.");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
