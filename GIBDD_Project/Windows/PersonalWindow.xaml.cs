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
    /// Логика взаимодействия для PersonalWindow.xaml
    /// </summary>
    public partial class PersonalWindow : Window
    {
        private TransportRepository transportRepository;
        public PersonalWindow()
        {
            InitializeComponent();
            Title = "Личный кабинет";
            transportRepository = new TransportRepository();
            personalGrid.ItemsSource = transportRepository.GetList();
        }


        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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
