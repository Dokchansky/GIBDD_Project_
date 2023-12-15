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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.IO;
using System.Reflection;
using GIBDD_Project.Infrastructure.Mappers;
using System.Runtime.Remoting.Messaging;
using GIBDD_Project.Windows;
using System.Data.Entity.Validation;

namespace GIBDD_Project.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private UserViewModel _selectedItem = null;// Переменная для хранения выбранного элемента 
        private UserRepository _repository = new UserRepository();// Репозиторий для работы с пользователями 
        private RoleRepository repository = new RoleRepository();// Репозиторий для работы с ролью 
        public AddUserWindow()
        {
            InitializeComponent();
            Title = "Добавление пользователя";
            var roles = _repository.GetRoles();
            role_user.ItemsSource = roles;
            role_user.SelectedItem = roles.FirstOrDefault();
        }

        public AddUserWindow(UserViewModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;

            if (_selectedItem != null)
            {
                surname_user.Text = _selectedItem.SurName;
                name_user.Text = _selectedItem.Name;
                patronymic_user.Text = _selectedItem.Patronymic;
                birthday_user.Text = _selectedItem.Birthday;
                gender_user.Text = _selectedItem.Gender;

                var roles = _repository.GetRoles();
                role_user.ItemsSource = roles;
                role_user.SelectedItem = roles.FirstOrDefault(p => p.RoleName == _selectedItem.RoleName);
            }
        }
        
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                RoleViewModel selected = role_user.SelectedItem as RoleViewModel;
                // Заполняем или обновляем данные в _selectedItem
                if (_selectedItem == null)
                {
                    _selectedItem = new UserViewModel();
                }
                if (role_user.SelectedValue == null || (long)role_user.SelectedValue == 0)
                {
                    throw new Exception("Группа должна быть выбрана");
                }
                // Заполняем или обновляем данные в _selectedItem
                _selectedItem.RoleID = (long)role_user.SelectedValue;
                _selectedItem.SurName = surname_user.Text;
                _selectedItem.Patronymic = patronymic_user.Text;
                _selectedItem.Name = name_user.Text;
                _selectedItem.Birthday = birthday_user.Text;
                _selectedItem.Gender = gender_user.Text;
                _selectedItem.RoleID = selected.ID;



                // Операция создания или обновления
                if (_selectedItem.ID == 0)
                {
                    // Создание нового элемента
                    _repository.Add(_selectedItem);
                    MessageBox.Show("Запись успешно добавлена.", "Сохранение завершено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Обновление существующего элемента
                    _repository.Update(_selectedItem);
                    MessageBox.Show("Запись успешно обновлена.", "Сохранение завершено", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                // Закрытие формы после сохранения данных
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Hide();
            UsersAdminWindow usersWindow = new UsersAdminWindow();
            usersWindow.Show();
        }
    }
}
