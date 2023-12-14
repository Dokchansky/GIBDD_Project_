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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private UserViewModel _selectedItem = null; // Переменная для хранения выбранного элемента
        private UserRepository _repository = new UserRepository();// Репозиторий для работы с клиентами
        private RoleRepository repository = new RoleRepository();// Репозиторий для работы с скидками
        public AddUserWindow()
        {
            InitializeComponent();
            Title = "Добавление пользователя";

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
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {

                RoleViewModel selectedDiscount = role_user.SelectedItem as RoleViewModel;
                UserEntity entity = new UserEntity  // Создание объекта с данными клиента
                {
                    SurName = surname_user.Text,
                    Name = name_user.Text,
                    Patronymic = patronymic_user.Text,
                    Birthday = birthday_user.Text,
                    Gender = gender_user.Text,
                };
                if (selectedDiscount == null)
                {
                    throw new Exception("Не все поля заполнены");// Выброс исключения, если не все поля заполнены
                }
                else
                {
                    entity.RoleID = selectedDiscount.ID;// Запись ID выбранной скидки
                }
                if (_selectedItem != null)
                {
                    entity.ID = _selectedItem.ID;
                    _repository.Update(entity);// Обновление данных клиента
                }
                else
                {
                    _repository.Add(entity);// Добавление нового клиента
                }

                MessageBox.Show("Запись успешно сохранена."); // Вывод сообщения об успешном сохранении
                this.Close(); // Закрытие окна
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Вывод сообщения об ошибке
            }
        }
        //private void FillFormFields()
        //{
        //    if (_selectedItem != null)
        //    {// Заполнение полей формы значениями выбранного элемента
        //        SurName.Text = _selectedItem.Name;
        //        SecondName.Text = _selectedItem.SecondName;
        //        MiddleName.Text = _selectedItem.MiddleName;
        //        DateOfBirth.Text = _selectedItem.DateOfBirth;
        //        Login.Text = _selectedItem.Login;
        //        Password.Text = _selectedItem.Password;
        //        Discountt.ItemsSource = repository.GetList();
        //        var result = new List<DiscountViewModel>();// Заполнение списка скидок в окне
        //        foreach (DiscountViewModel discount in Discountt.ItemsSource)
        //        {
        //            if (_selectedItem.DiscountId == discount.Id)
        //            {
        //                Discountt.SelectedItem = discount;// Установка выбранного элемента в списке скидок
        //                break;
        //            }
        //            else
        //            {
        //                result.Add(discount);
        //            }
        //            Discountt.SelectedItem = result[0];// Установка первого элемента списка скидок по умолчанию
        //        }
        //    }
        //}
    }
}
