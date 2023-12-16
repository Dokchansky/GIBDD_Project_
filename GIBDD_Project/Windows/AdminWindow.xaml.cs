using GIBDD_Project.Infrastructure.Consts;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        public AdminWindow()
        {
            InitializeComponent();
            Title = "Окно администратора";
            userNameTextBox.Text = Application.Current.Resources[UserInfoConsts.UserName].ToString(); // Вывод логина пользователя в окно
            roleTextBox.Text = Application.Current.Resources[UserInfoConsts.RoleName].ToString(); // Вывод роли пользователя в окно

        }

        private void Button_Personal(object sender, RoutedEventArgs e) // Кнопка перехода в окно Автомобили
        {
            Hide();
            PersonalAdminWindow personalWindow = new PersonalAdminWindow();
            personalWindow.Show();
            Close();
        }

        private void Button_Fines(object sender, RoutedEventArgs e) // Кнопка перехода в окно Штрафы
        {
            Hide();
            FineAdminWindow fineWindow = new FineAdminWindow();
            fineWindow.Show();
            Close();
        }
        private void Button_Exit(object sender, RoutedEventArgs e) // Кнопка выхода
        {
            Hide();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
        private void Button_Users(object sender, RoutedEventArgs e) // Кнопка перехода в окно Пользователи
        {
            Hide();
            UsersAdminWindow usersadminWindow = new UsersAdminWindow();
            usersadminWindow.Show();
            Close();
        }


    }
}
