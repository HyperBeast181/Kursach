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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace WpfApp1.Xaml
{
    public class DatabaseAccess
    {
        private readonly string connectionString;

        public DatabaseAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AirlineTicketingDBConnectionString"].ConnectionString;
        }

        public void OpenConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Соединение с базой данных успешно установлено.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при подключении к базе данных: " + ex.Message);
                }
            }
        }

        public DataTable GetFlights()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Рейсы";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable("Рейсы");
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при получении данных из базы данных: " + ex.Message);
                    return null;
                }
            }
        }
        public DataTable GetPassengers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Пассажиры";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable("Пассажиры");
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при получении данных о пассажирах: " + ex.Message);
                    return null;
                }
            }
        }

        public DataTable GetTariffs()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Тарифы";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable("Тарифы");
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при получении данных о тарифах: " + ex.Message);
                    return null;
                }
            }
        }

        public DataTable GetCashiers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Кассиры";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable("Кассиры");
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при получении данных о кассирах: " + ex.Message);
                    return null;
                }
            }
        }

        //New Passangers
        public void AddPassenger(string фамилия, string имя, string отчество, string пол, DateTime дата_рождения, string номер_паспорта, string страна_проживания, string мобильный_телефон, string электронная_почта)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"INSERT INTO Пассажиры (Фамилия, Имя, Отчество, Пол, Дата_рождения, Номер_паспорта, Страна_проживания, Мобильный_телефон, Электронная_почта) VALUES (@Фамилия, @Имя, @Отчество, @Пол, @Дата_рождения, @Номер_паспорта, @Страна_проживания, @Мобильный_телефон, @Электронная_почта)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Фамилия", фамилия);
                    command.Parameters.AddWithValue("@Имя", имя);
                    command.Parameters.AddWithValue("@Отчество", отчество);
                    command.Parameters.AddWithValue("@Пол", пол);
                    command.Parameters.AddWithValue("@Дата_рождения", дата_рождения);
                    command.Parameters.AddWithValue("@Номер_паспорта", номер_паспорта);
                    command.Parameters.AddWithValue("@Страна_проживания", страна_проживания);
                    command.Parameters.AddWithValue("@Мобильный_телефон", мобильный_телефон);
                    command.Parameters.AddWithValue("@Электронная_почта", электронная_почта);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePassenger(int id_пассажира)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Пассажиры WHERE ID_пассажира = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id_пассажира);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        //Reisi
        public void AddFlight(string номерРейса, DateTime датаВылета, TimeSpan времяВылета, string аэропортВылета, string аэропортПрилета, TimeSpan времяВПути, int расстояние, decimal стоимость)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = @"
                    INSERT INTO Рейсы (Номер_рейса, Дата_вылета, Время_вылета, Аэропорт_вылета, Аэропорт_прилета, Время_в_пути, Расстояние, Стоимость_маршрута) 
                    VALUES (@НомерРейса, @ДатаВылета, @ВремяВылета, @АэропортВылета, @АэропортПрилета, @ВремяВПути, @Расстояние, @Стоимость)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@НомерРейса", номерРейса);
                        command.Parameters.AddWithValue("@ДатаВылета", датаВылета);
                        command.Parameters.AddWithValue("@ВремяВылета", времяВылета);
                        command.Parameters.AddWithValue("@АэропортВылета", аэропортВылета);
                        command.Parameters.AddWithValue("@АэропортПрилета", аэропортПрилета);
                        command.Parameters.AddWithValue("@ВремяВПути", времяВПути);
                        command.Parameters.AddWithValue("@Расстояние", расстояние);
                        command.Parameters.AddWithValue("@Стоимость", стоимость);

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при добавлении рейса в базу данных: " + ex.Message);
                    throw;
                }
            }
        }
        public void DeleteFlight(int idРейса)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM Рейсы WHERE ID_рейса = @IDРейса";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IDРейса", idРейса);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при удалении рейса из базы данных: " + ex.Message);
                    throw;
                }
            }
        }

        //Tarifs
        public void AddTariff(string название, bool возвратБилета, bool измененияБронирования, int багажноеДопущение, bool бесплатноеПитание, string типМеста)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = @"
                    INSERT INTO Тарифы (Название_тарифа, Возврат_билета, Изменения_бронирования, Багажное_допущение, Бесплатное_питание, Тип_места) 
                    VALUES (@Название, @ВозвратБилета, @ИзмененияБронирования, @БагажноеДопущение, @БесплатноеПитание, @ТипМеста)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Название", название);
                        command.Parameters.AddWithValue("@ВозвратБилета", возвратБилета);
                        command.Parameters.AddWithValue("@ИзмененияБронирования", измененияБронирования);
                        command.Parameters.AddWithValue("@БагажноеДопущение", багажноеДопущение);
                        command.Parameters.AddWithValue("@БесплатноеПитание", бесплатноеПитание);
                        command.Parameters.AddWithValue("@ТипМеста", типМеста);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при добавлении тарифа в базу данных: " + ex.Message);
                    throw;
                }
            }
        }
        public void UpdateTariff(int idТарифа, string название, bool возвратБилета, bool измененияБронирования, int багажноеДопущение, bool бесплатноеПитание, string типМеста)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = @"
                    UPDATE Тарифы
                    SET Название_тарифа = @Название,
                    Возврат_билета = @ВозвратБилета,
                    Изменения_бронирования = @ИзмененияБронирования,
                    Багажное_допущение = @БагажноеДопущение,
                    Бесплатное_питание = @БесплатноеПитание,
                    Тип_места = @ТипМеста
                    WHERE ID_тарифа = @IDТарифа";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IDТарифа", idТарифа);
                        command.Parameters.AddWithValue("@Название", название);
                        command.Parameters.AddWithValue("@ВозвратБилета", возвратБилета);
                        command.Parameters.AddWithValue("@ИзмененияБронирования", измененияБронирования);
                        command.Parameters.AddWithValue("@БагажноеДопущение", багажноеДопущение);
                        command.Parameters.AddWithValue("@БесплатноеПитание", бесплатноеПитание);
                        command.Parameters.AddWithValue("@ТипМеста", типМеста);

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при обновлении тарифа в базе данных: " + ex.Message);
                    throw;
                }
            }
        }

        public void DeleteTariff(int idТарифа)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM Тарифы WHERE ID_тарифа = @IDТарифа";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IDТарифа", idТарифа);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при удалении тарифа из базы данных: " + ex.Message);
                    throw;
                }
            }
        }


        //Cashier
        public void AddCashier(string фио, string номерОфиса)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = @"
                    INSERT INTO Кассиры (ФИО, Номер_офиса) 
                    VALUES (@ФИО, @НомерОфиса)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ФИО", фио);
                        command.Parameters.AddWithValue("@НомерОфиса", номерОфиса);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при добавлении кассира: " + ex.Message);
                    throw;
                }
            }
        }

        public void UpdateCashier(int idКассира, string фио, string номерОфиса)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = @"
                    UPDATE Кассиры
                    SET ФИО = @ФИО, Номер_офиса = @НомерОфиса
                    WHERE ID_кассира = @IDКассира";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IDКассира", idКассира);
                        command.Parameters.AddWithValue("@ФИО", фио);
                        command.Parameters.AddWithValue("@НомерОфиса", номерОфиса);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при обновлении данных кассира: " + ex.Message);
                    throw;
                }
            }
        }

        public void DeleteCashier(int idКассира)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM Кассиры WHERE ID_кассира = @IDКассира";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IDКассира", idКассира);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Ошибка при удалении кассира: " + ex.Message);
                    throw;
                }
            }
        }






    }


    public partial class sotrudnick : Window
    {
        private DatabaseAccess dbAccess;

        public sotrudnick()
        {
            InitializeComponent();
            dbAccess = new DatabaseAccess();
            LoadFlightsData();
            LoadPassengersData();
            LoadTariffsData();
            LoadCashiersData();
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
        private void LoadFlightsData()
        {
            DataTable flightsTable = dbAccess.GetFlights();
            if (flightsTable != null)
            {
                flightsDataGrid.ItemsSource = flightsTable.DefaultView;
            }
        }
        private void LoadPassengersData()
        {
            DataTable passengersTable = dbAccess.GetPassengers();
            if (passengersTable != null)
            {
                passengersDataGrid.ItemsSource = passengersTable.DefaultView;
            }
        }

        private void LoadTariffsData()
        {
            DataTable tariffsTable = dbAccess.GetTariffs();
            if (tariffsTable != null)
            {
                tariffsDataGrid.ItemsSource = tariffsTable.DefaultView;
            }
        }

        private void LoadCashiersData()
        {
            DataTable cashiersTable = dbAccess.GetCashiers();
            if (cashiersTable != null)
            {
                cashiersDataGrid.ItemsSource = cashiersTable.DefaultView;
            }
        }


        private void OnFlightSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //NewPassangers

        private void AddPassenger_Click(object sender, RoutedEventArgs e)
        {
            string фамилия = фамилияTextBox.Text;
            string имя = имяTextBox.Text;
            string отчество = отчествоTextBox.Text;
            string пол = полComboBox.SelectedItem is ComboBoxItem selectedItem ? selectedItem.Content.ToString() : string.Empty;
            DateTime? дата_рождения = дата_рожденияDatePicker.SelectedDate;
            string номер_паспорта = номер_паспортаTextBox.Text;
            string страна_проживания = страна_проживанияTextBox.Text;
            string мобильный_телефон = мобильный_телефонTextBox.Text;
            string электронная_почта = электронная_почтаTextBox.Text;

            if (дата_рождения.HasValue)
            {
                dbAccess.AddPassenger(фамилия, имя, отчество, пол, дата_рождения.Value, номер_паспорта, страна_проживания, мобильный_телефон, электронная_почта);
                LoadPassengersData();
            }
            else
            {
                MessageBox.Show("Выберите дату рождения.");
            }
        }

        private void DeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            if (passengersDataGrid.SelectedItem is DataRowView selectedRow)
            {
                int id_пассажира = Convert.ToInt32(selectedRow.Row["ID_пассажира"]);
                dbAccess.DeletePassenger(id_пассажира);
                LoadPassengersData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пассажира для удаления.");
            }
        }


        //Reisi

        private void AddFlight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var номерРейса = txtНомерРейса.Text;
                var датаВылета = dpДатаВылета.SelectedDate.Value.Date;
                var времяВылета = TimeSpan.Parse(txtВремяВылета.Text); // Пример формата: "14:00"
                var аэропортВылета = txtАэропортВылета.Text;
                var аэропортПрилета = txtАэропортПрилета.Text;
                var времяВПути = TimeSpan.Parse(txtВремяВПути.Text); // Пример формата: "01:30"
                var расстояние = int.Parse(txtРасстояние.Text);
                var стоимость = decimal.Parse(txtСтоимость.Text);

                dbAccess.AddFlight(номерРейса, датаВылета, времяВылета, аэропортВылета, аэропортПрилета, времяВПути, расстояние, стоимость);
                LoadFlightsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении рейса: {ex.Message}");
            }
        }


        private void DeleteFlights_Click(object sender, RoutedEventArgs e)
        {
            if (flightsDataGrid.SelectedItem is DataRowView selectedRow)
            {
                int idРейса = Convert.ToInt32(selectedRow.Row["ID_рейса"]);
                dbAccess.DeleteFlight(idРейса);
                LoadFlightsData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите рейс для удаления.");
            }
        }



        //Tarifs

        private void AddTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string название = txtНазваниеТарифа.Text;
                bool возвратБилета = chkВозвратБилета.IsChecked ?? false;
                bool измененияБронирования = chkИзмененияБронирования.IsChecked ?? false;
                int багажноеДопущение = int.Parse(txtБагажноеДопущение.Text); // Обязательно число
                bool бесплатноеПитание = chkБесплатноеПитание.IsChecked ?? false;
                string типМеста = txtТипМеста.Text;

                dbAccess.AddTariff(название, возвратБилета, измененияБронирования, багажноеДопущение, бесплатноеПитание, типМеста);
                LoadTariffsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении тарифа: {ex.Message}");
            }

        }


        private void EditTariff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tariffsDataGrid.SelectedItem is DataRowView selectedRow)
                {
                    int idТарифа = Convert.ToInt32(selectedRow.Row["ID_тарифа"]);
                    string название = txtНазваниеТарифа.Text;
                    bool возвратБилета = chkВозвратБилета.IsChecked ?? false;
                    bool измененияБронирования = chkИзмененияБронирования.IsChecked ?? false;
                    int багажноеДопущение = int.Parse(txtБагажноеДопущение.Text);
                    bool бесплатноеПитание = chkБесплатноеПитание.IsChecked ?? false;
                    string типМеста = txtТипМеста.Text;

                    dbAccess.UpdateTariff(idТарифа, название, возвратБилета, измененияБронирования, багажноеДопущение, бесплатноеПитание, типМеста);
                    LoadTariffsData();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите тариф для редактирования.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании тарифа: {ex.Message}");
            }
        }

        private void DeleteTariff_Click(object sender, RoutedEventArgs e)
        {
            if (tariffsDataGrid.SelectedItem is DataRowView selectedRow)
            {
                int idТарифа = Convert.ToInt32(selectedRow.Row["ID_тарифа"]);
                var result = MessageBox.Show("Вы уверены, что хотите удалить этот тариф?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    dbAccess.DeleteTariff(idТарифа);
                    LoadTariffsData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тариф для удаления.");
            }
        }



        //Cashier


        private void AddCashier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string фио = txtФИО.Text;
                string номерОфиса = txtНомерОфиса.Text;

                dbAccess.AddCashier(фио, номерОфиса);
                LoadCashiersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении кассира: {ex.Message}");
            }
        }

        private void EditCashier_Click(object sender, RoutedEventArgs e)
        {
            if (cashiersDataGrid.SelectedItem is DataRowView selectedRow)
            {
                try
                {
                    int idКассира = Convert.ToInt32(selectedRow.Row["ID_кассира"]);
                    string фио = txtФИО.Text;
                    string номерОфиса = txtНомерОфиса.Text;

                    dbAccess.UpdateCashier(idКассира, фио, номерОфиса);
                    LoadCashiersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании данных кассира: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите кассира для редактирования.");
            }
        }

        private void DeleteCashier_Click(object sender, RoutedEventArgs e)
        {
            if (cashiersDataGrid.SelectedItem is DataRowView selectedRow)
            {
                try
                {
                    int idКассира = Convert.ToInt32(selectedRow.Row["ID_кассира"]);
                    dbAccess.DeleteCashier(idКассира);
                    LoadCashiersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении кассира: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите кассира для удаления.");
            }
        }
    }
}


