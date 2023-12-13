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
        private CarCategoryRepository carCategoryRepository;
        private UserViewModel userViewModel;
        private TransportViewModel transportViewModel;
        private BrandViewModel brandViewModel;
        private BrandRepository brandRepository;
        public PersonalWindow()
        {
            InitializeComponent();
            Title = "Личный кабинет";
            brandRepository = new BrandRepository();
            transportRepository = new TransportRepository();
            brandViewModel = new BrandViewModel();
        }


        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
