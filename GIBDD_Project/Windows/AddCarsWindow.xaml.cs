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
        private TransportRepository _repository = new TransportRepository();// Репозиторий для работы с сотрудниками
        private UserViewModel _selectedItem3 = null;
        private UserRepository repository = new UserRepository();// Репозиторий для работы с должностями
        private BrandViewModel _selectedItem1 = null;
        private BrandRepository _repository1 = new BrandRepository();
        private CarCategoryViewModel _selectedItem2 = null;
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
            _selectedItem = selectedItem;
            FillFormFields();// Заполнение полей формы выбранными значениями
            _selectedItem2 = selectedItem2;
            _selectedItem1 = selectedItem1;
            _selectedItem3 = selectedItem3;
        }
        private void FillFormFields()
        {
            if (_selectedItem != null && _selectedItem1 != null && _selectedItem2 != null)
            {// Заполнение полей формы значениями выбранного элемента
                brand_name.Text = _selectedItem.BrandName;
                year_car.Text = _selectedItem.Year;
                state_number.Text = _selectedItem.StateNumber;
                status_car.Text = _selectedItem.Status;
                user_login.ItemsSource = repository.GetList();
                var result = new List<UserViewModel>();// Заполнение списка должностей в окне
                foreach (UserViewModel state in user_login.ItemsSource)
                {
                    if (_selectedItem3.Login == state.Login)
                    {
                        user_login.SelectedItem = state;// Установка выбранного элемента в списке должностей
                        break;
                    }
                    else
                    {
                        result.Add(state);
                    }
                    user_login.SelectedItem = result[0];// Установка первого элемента списка должностей по умолчанию
                }
                car_category.ItemsSource = _repository2.GetList();
                var result2 = new List<CarCategoryViewModel>();// Заполнение списка должностей в окне
                foreach (CarCategoryViewModel state2 in car_category.ItemsSource)
                {
                    if (_selectedItem2.Name == state2.Name)
                    {
                        car_category.SelectedItem = state2;// Установка выбранного элемента в списке должностей
                        break;
                    }
                    else
                    {
                        result2.Add(state2);
                    }
                    car_category.SelectedItem = result2[0];// Установка первого элемента списка должностей по умолчанию
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CarCategoryViewModel selected2 = new CarCategoryViewModel();
                UserViewModel selected = new UserViewModel();
                CarCategoryEntity entity2 = new CarCategoryEntity();
                BrandEntity entity1 = new BrandEntity()
                {
                    Name = brand_name.Text,
                };
    
                TransportEntity entity = new TransportEntity()
                {
                    CarCategoryID = selected2.ID,
                    Year = year_car.Text,
                    StateNumber = state_number.Text,
                    Status = status_car.Text,
                    UserID = selected.ID,
                };
                    // Создание объекта с данными программ занятий

                


                if (_selectedItem != null && _selectedItem1 != null && _selectedItem2 != null && _selectedItem3 != null)
                {
                    entity.ID = _selectedItem.ID;
                    entity1.ID = _selectedItem1.ID;
                    _repository.Update(entity, entity1);// Обновление данных программы занятий
                }
                else
                {
                    _repository.Add(entity, entity1);// Добавление новой программы занятий
                }

                MessageBox.Show("Запись успешно сохранена.");// Вывод сообщения об успешном сохранении
                this.Close();// Закрытие окна
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// Вывод сообщения об ошибке
            }

        }
    }
}
