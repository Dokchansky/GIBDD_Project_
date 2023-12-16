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
        private UserRepository _repository = new UserRepository();// Репозиторий для работы с сотрудниками
        private RoleRepository repository = new RoleRepository();// Репозиторий для работы с должностями
        public AddUserWindow()
        {
            InitializeComponent();
            role_user.ItemsSource = repository.GetList();// Заполнение списка должностей в окне
        }

        public AddUserWindow(UserViewModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;
            FillFormFields();// Заполнение полей формы выбранными значениями
        }
        private void FillFormFields()
        {
            if (_selectedItem != null)
            {// Заполнение полей формы значениями выбранного элемента
                name_user.Text = _selectedItem.Name;
                surname_user.Text = _selectedItem.SurName;
                patronymic_user.Text = _selectedItem.Patronymic;
                birthday_user.Text = _selectedItem.Birthday;
                login_user.Text = _selectedItem.Login;
                password_user.Text = _selectedItem.Password;
                gender_user.Text = _selectedItem.Gender;
                role_user.ItemsSource = repository.GetList();
                var result = new List<RoleViewModel>();// Заполнение списка должностей в окне
                foreach (RoleViewModel role in role_user.ItemsSource)
                {
                    if (_selectedItem.Role.Name == role.Name)
                    {
                        role_user.SelectedItem = role;// Установка выбранного элемента в списке должностей
                        break;
                    }
                    else
                    {
                        result.Add(role);
                    }
                    role_user.SelectedItem = result[0];// Установка первого элемента списка должностей по умолчанию
                }

            }
        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                RoleViewModel selected = role_user.SelectedItem as RoleViewModel;// Получение выбранной должности
                UserEntity entity = new UserEntity // Создание объекта с данными сотрудника
                {
                    Name = name_user.Text,
                    SurName = surname_user.Text,
                    Patronymic = patronymic_user.Text,
                    Birthday = birthday_user.Text,
                    Login = login_user.Text,
                    Password = password_user.Text,
                    Gender = gender_user.Text,
                    RoleID = selected.ID// Запись ID выбранной должности
                };


                if (_selectedItem != null)
                {
                    entity.ID = _selectedItem.ID;
                    _repository.Update(entity);// Обновление данных сотрудника
                }
                else
                {
                    _repository.Add(entity);// Добавление нового сотрудника
                }

                MessageBox.Show("Запись успешно сохранена.");// Вывод сообщения об успешном сохранении  
                UsersAdminWindow userWindow = new UsersAdminWindow();
                userWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// Вывод сообщения об ошибке
            }
        }
    }
}
