using GIBDD_Project.Infrastructure;
using GIBDD_Project.Infrastructure.Database;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace GIBDD_Project.Windows
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        private UserViewModel _userViewModel;
        private UserRepository userRepository;
        public UsersWindow()
        {
            InitializeComponent();
            Title = "Список пользователей";
            _userViewModel = new UserViewModel();
            userRepository = new UserRepository();
          
            userGrid.ItemsSource = userRepository.GetList();
        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Hide();
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.Show();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (userGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран объект для удаления");
                return;
            }

            var item = userGrid.SelectedItem as UserViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
                return;
            }

            userRepository.Delete(item.ID);
            //UpdateGrid();
        }
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {

            //try
            //{
            //    var reportManager = new ReportManager();
            //    var data = reportManager.GenerateReport(ClientsGrid.ItemsSource as List<ClientViewModel>);

            //    var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Клиенты_{DateTime.Now.ToShortDateString()}.xlsx");
            //    using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            //    {
            //        stream.Write(data, 0, data.Length);
            //    }
            //    MessageBox.Show("Выгрузка успешна");
            //}
            //catch
            //{
            //    MessageBox.Show("Выгрузка неуспешна");
            //}

        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            //if (userGrid.SelectedItem != null)
            //{
            //    var qrManager = new QRManager();
            //    var qrCodeImage = qrManager.Generate(ClientsGrid.SelectedItem);
            //    var qrWindow = new QRWindow();
            //    qrWindow.qrImage.Source = qrCodeImage;
            //    qrWindow.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Объект не выбран");
            //}
        }
        private void Button_Click (object sender, RoutedEventArgs e)
        {

        }
    }
}
