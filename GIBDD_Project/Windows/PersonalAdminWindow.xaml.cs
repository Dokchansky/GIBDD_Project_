using GIBDD_Project.Infrastructure.Database;
using GIBDD_Project.Infrastructure.QR;
using GIBDD_Project.Infrastructure.Report;
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
    /// Логика взаимодействия для PersonalAdminWindow.xaml
    /// </summary>
    public partial class PersonalAdminWindow : Window
    {

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
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Hide();
            AddCarsWindow addCarsWindow = new AddCarsWindow();
            addCarsWindow.Show();
            Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли автомобиль для удаления.
            if (personalGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран объект для удаления");
                return;
            }
            // Получение выбранного объекта из таблицы
            var item = personalGrid.SelectedItem as TransportViewModel;
            // Проверка, удалось ли получить данные о автомобиле
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
                return;
            }
            // Удаление автомобиля из репозитория и обновление данных в таблице.
            transportRepository.Delete(item.ID);
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            personalGrid.ItemsSource = transportRepository.GetList();// Установка источника данных таблицы из репозитория.
        }
        private void ExportButton_Click(object sender, RoutedEventArgs e) // Выгрузка данных в Excel
        {

            try
            {
                var reportManager = new ReportManager();
                var data = reportManager.GenerateReport(personalGrid.ItemsSource as List<TransportViewModel>);

                var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Авто_{DateTime.Now.ToShortDateString()}.xlsx");
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    stream.Write(data, 0, data.Length);
                }
                MessageBox.Show("Выгрузка успешна");
            }
            catch
            {
                MessageBox.Show("Выгрузка неуспешна");
            }

        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e) // Генерация QR кода
        {
            if (personalGrid.SelectedItem != null)
            {
                var qrManager = new QRManager();
                var qrCodeImage = qrManager.Generate(personalGrid.SelectedItem);
                var qrWindow = new QRWindow();
                qrWindow.qrImage.Source = qrCodeImage;
                qrWindow.Show();
            }
            else
            {
                MessageBox.Show("Объект не выбран");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string search = find.Text;
            if (string.IsNullOrEmpty(search))
            {
                personalGrid.ItemsSource = transportRepository.GetList(); // Показать все элементы, если запрос пуст.
            }

            else
            {
                List<TransportViewModel> searchResult = transportRepository.Search(search);// Выполнить поиск по запросу.
                personalGrid.ItemsSource = searchResult;// Отобразить результаты поиска.
            }
            
        }
        
    }
}
