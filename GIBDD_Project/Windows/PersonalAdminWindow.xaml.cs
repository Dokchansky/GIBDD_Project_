using GIBDD_Project.Infrastructure.Database;
using GIBDD_Project.Infrastructure.ViewModels;
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

namespace GIBDD_Project.Windows
{
    /// <summary>
    /// Логика взаимодействия для PersonalAdminWindow.xaml
    /// </summary>
    public partial class PersonalAdminWindow : Window
    {
        private UserViewModel _userViewModel;
        private UserRepository userRepository;
        private TransportRepository transportRepository;
        public PersonalAdminWindow()
        {
            InitializeComponent();
            Title = "Автомобили";
            transportRepository = new TransportRepository();
            personalGrid.ItemsSource = transportRepository.GetList();
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
            AddCarsWindow addCarsWindow = new AddCarsWindow();
            addCarsWindow.Show();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (personalGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран объект для удаления");
                return;
            }

            var item = personalGrid.SelectedItem as UserViewModel;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string search = find.Text;
            if (string.IsNullOrEmpty(search))
            {
                personalGrid.ItemsSource = userRepository.GetList(); // Показать все элементы, если запрос пуст.
            }

            else
            {
                List<UserViewModel> searchResult = userRepository.Search(search);// Выполнить поиск по запросу.
                personalGrid.ItemsSource = searchResult;// Отобразить результаты поиска.
            }
        }
    }
}
