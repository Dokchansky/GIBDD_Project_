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
                surname_user.Text = _selectedItem.SurName;
                name_user.Text = _selectedItem.Name;
                patronymic_user.Text = _selectedItem.Patronymic;
                birthday_user.Text = _selectedItem.Birthday;
                gender_user.Text = _selectedItem.Gender;
                role_user.ItemsSource = repository.GetList();
                var result = new List<RoleViewModel>();// Заполнение списка должностей в окне
                foreach (RoleViewModel discount in role_user.ItemsSource)
                {
                    if (_selectedItem.Role.Name == discount.Name)
                    {
                        role_user.SelectedItem = discount;// Установка выбранного элемента в списке должностей
                        break;
                    }
                    else
                    {
                        result.Add(discount);
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
                    SurName = surname_user.Text,
                    Name = name_user.Text,
                    Patronymic = patronymic_user.Text,
                    Birthday = birthday_user.Text,
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
                this.Close();// Закрытие окна
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// Вывод сообщения об ошибке
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
