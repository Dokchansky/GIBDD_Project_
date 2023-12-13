using GIBDD_Project.Infrastructure;
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
    }
}
