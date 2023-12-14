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
        public AddCarsWindow()
        {
            InitializeComponent();
        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide();
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Hide();
            PersonalAdminWindow personalWindow = new PersonalAdminWindow();
            personalWindow.Show();
            Close();
        }
        private TransportViewModel _selectedItem = null;// Переменная для хранения выбранного элемента
        private TransportRepository _repository = new TransportRepository();// Репозиторий для работы с программами занятий
        private BrandViewModel _selectedItem1 = null;
        private BrandRepository _repository1 = new BrandRepository();
        public AddCarsWindow(TransportViewModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;
            FillFormFields();// Заполнение полей формы выбранными значениями
        }
        private void FillFormFields()
        {
            if (_selectedItem != null)
            {// Заполнение полей формы значениями выбранного элемента
                brand_name.Text = _selectedItem.BrandName;
                car_category.Text = _selectedItem.CarCategoryName;
                year_car.Text = _selectedItem.Year;
                state_number.Text = _selectedItem.StateNumber;
                status_car.Text = _selectedItem.Status;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TransportEntity entity = new TransportEntity();
                BrandEntity entity1 = new BrandEntity();// Создание объекта с данными программ занятий
                CarCategoryEntity entity2 = new CarCategoryEntity();
                entity1.Name = brand_name.Text;
                entity2.Name = car_category.Text;
                entity.Year = year_car.Text;
                entity.StateNumber = state_number.Text;
                entity.Status = status_car.Text;


                if (_selectedItem != null && _selectedItem1 != null)
                {
                    entity.ID = _selectedItem.ID; 
                    entity1.ID = _selectedItem.BrandID;
                    _repository.Update(entity, entity1, entity2);// Обновление данных программы занятий
                }
                else
                {
                    _repository.Add(entity, entity1, entity2);// Добавление новой программы занятий
                }
                if (_selectedItem1 != null) 
                {
                    entity1.ID = _selectedItem1.ID;
                    _repository1.Update(entity, entity1,entity2);

                }
                else
                {
                    _repository1.Add(entity,entity1, entity2);
                }
                

                MessageBox.Show("Запись успешно сохранена.");// Вывод сообщения об успешном сохранении
                this.Close();// Закрытие окна
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message);// Вывод сообщения об ошибке
            }

        }
    }
}
