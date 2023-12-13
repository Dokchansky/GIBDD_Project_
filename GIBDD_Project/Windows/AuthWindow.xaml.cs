using GIBDD_Project.Infrastructure.Consts;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private UserRepository _userRepository;
        private UserViewModel _userViewModel;
        public AuthWindow()
        {
            InitializeComponent();
            Title = "Окно авторизации";
            _userRepository = new UserRepository();
            _userViewModel = new UserViewModel();

        }


        private void Button_Login(object sender, EventArgs e)
        {
            string login = loginBox.Text;
            string password = passwordBox.Password;


            _userRepository.Login(login, password);
            if (login == "" && password == "")
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми строками!");
                return;
            }
            if (login == "")
            {
                MessageBox.Show("Логин не может быть пустой строкой!");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("Пароль не может быть пустой строкой!");
                return;
            }


            using (Infrastructure.Context context = new Infrastructure.Context())
            {
                var user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password && x.RoleID == 2);
                var user1 = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password && x.RoleID == 1);
                if (user != null)
                {
                    Application.Current.Resources[UserInfoConsts.RoleID] = 2;
                    Application.Current.Resources[UserInfoConsts.RoleName] = " Пользователь";
                    Application.Current.Resources[UserInfoConsts.UserName] = $" {login}";
                    Hide();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show(); ;
                }
                else if (user1 != null)
                {
                    Application.Current.Resources[UserInfoConsts.RoleID] = 1;
                    Application.Current.Resources[UserInfoConsts.RoleName] = " Администратор";
                    Application.Current.Resources[UserInfoConsts.UserName] = $" {login}";
                    Hide();
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show(); ;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
            }



        }

        private void Button_Guest(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.RoleID] = 3;
            Application.Current.Resources[UserInfoConsts.RoleName] = " Гость";
            Application.Current.Resources[UserInfoConsts.UserName] = " Гость";
            Hide();
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
