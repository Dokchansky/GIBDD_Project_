using GIBDD_Project.Infrastructure.Database;
using GIBDD_Project.Infrastructure.ViewModels;
using GIBDD_Project.Infrastructure;
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
using System.Data.Entity.Validation;

namespace GIBDD_Project.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCarsWindow.xaml
    /// </summary>
    public partial class AddCarsWindow : Window
    {
        private TransportViewModel _selectedItem = null;// Переменная для хранения выбранного элемента
        private TransportRepository _repository = new TransportRepository();// Репозиторий для работы с автомобилями
        private UserViewModel _selectedItem3 = null;
        private UserRepository repository = new UserRepository();// Репозиторий для работы с пользователями
        private BrandViewModel _selectedItem1 = null;
        private BrandRepository _repository1 = new BrandRepository(); // Репозиторий для работы с марками
        private CarCategoryViewModel _selectedItem2 = null; // Репозиторий для работы с типами кузова
        private CarCategoryRepository _repository2 = new CarCategoryRepository();


        public AddCarsWindow()
        {
            InitializeComponent();
            user_login.ItemsSource = repository.GetList();
            car_category.ItemsSource = _repository2.GetList();
        }


        public AddCarsWindow(TransportViewModel selectedItem, CarCategoryViewModel selectedItem2, BrandViewModel selectedItem1, UserViewModel selectedItem3)
        {
            InitializeComponent();
          
            _selectedItem2 = selectedItem2;
            _selectedItem1 = selectedItem1;
            _selectedItem3 = selectedItem3;
            FillFormFields();// Заполнение полей формы выбранными значениями
            _selectedItem = selectedItem;
        }
       





        private void FillFormFields()
        {
            if (_selectedItem != null && _selectedItem1 != null && _selectedItem2 != null && _selectedItem3 != null)
            {// Заполнение полей формы значениями выбранного элемента
                brand_name.Text = _selectedItem.BrandName;
                year_car.Text = _selectedItem.Year;
                state_number.Text = _selectedItem.StateNumber;
                status_car.Text = _selectedItem.Status;
                user_login.ItemsSource = repository.GetList();
                car_category.ItemsSource = _repository2.GetList();
                var result = new List<UserViewModel>();// Заполнение списка пользователей в окне
                foreach (UserViewModel state in user_login.ItemsSource)
                {
                    if (_selectedItem3.Login == state.Login)
                    {
                        user_login.SelectedItem = state;// Установка выбранного элемента в списке пользователей
                        break;
                    }
                    else
                    {
                        result.Add(state);
                    }
                    user_login.SelectedItem = result[0];// Установка первого элемента списка пользователей по умолчанию
                }

                var result2 = new List<CarCategoryViewModel>();// Заполнение списка типов кузова в окне
                foreach (CarCategoryViewModel state2 in car_category.ItemsSource)
                {
                    if (_selectedItem2.Name == state2.Name)
                    {
                        car_category.SelectedItem = state2;// Установка выбранного элемента в списке типов кузова
                        break;
                    }
                    else
                    {
                        result2.Add(state2);
                    }
                    car_category.SelectedItem = result2[0];// Установка первого элемента списка типов кузова по умолчанию
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) // Кнопка Добавить
        {
            try
            {
                // Преобразование выбранного элемента в модели представления типа кузова автомобиля
                CarCategoryViewModel selected2 = car_category.SelectedItem as CarCategoryViewModel;
                // Преобразование выбранного элемента в модели представления пользователя
                UserViewModel selected = user_login.SelectedItem as UserViewModel;
                // Создание экземпляра сущности типа кузова автомобиля
                CarCategoryEntity entity2 = new CarCategoryEntity();
                // Создание экземпляра сущности марки с установленным именем
                BrandEntity entity1 = new BrandEntity()
                {
                    Name = brand_name.Text,
                };
                // Создание экземпляра сущности транспорта с установленными свойствами
                TransportEntity entity = new TransportEntity()
                {
                    CarCategoryID = selected2.ID,
                    Year = year_car.Text,
                    StateNumber = state_number.Text,
                    Status = status_car.Text,
                    UserID = selected.ID,
                };


                if (_selectedItem != null && _selectedItem1 != null && _selectedItem2 != null && _selectedItem3 != null)
                {
                    entity.ID = _selectedItem.ID;
                    entity1.ID = _selectedItem1.ID;
                    _repository.Update(entity, entity1);// Обновление данных транспорта
                }
                else
                {
                    _repository.Add(entity, entity1);// Добавление новых данных
                }

                MessageBox.Show("Запись успешно сохранена.");// Вывод сообщения об успешном сохранении  
                PersonalAdminWindow addCarsWindow = new PersonalAdminWindow();
                addCarsWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// Вывод сообщения об ошибке

            }



        }
    }
}
