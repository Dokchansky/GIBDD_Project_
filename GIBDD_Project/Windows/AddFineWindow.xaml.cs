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
    /// Логика взаимодействия для AddFineWindow.xaml
    /// </summary>
    public partial class AddFineWindow : Window
    {
        private FineViewModel _selectedItem = null;// Переменная для хранения выбранного элемента
        private FineRepository _repository = new FineRepository();// Репозиторий для работы со штрафами
        private TransportViewModel _selectedItem2 = null;
        private TransportRepository repository = new TransportRepository();// Репозиторий для работы с автомобилями 
        public AddFineWindow()
        {
            InitializeComponent();
            state_number.ItemsSource = repository.GetList();// Заполнение списка гос.номеров в окне
        }

        public AddFineWindow(FineViewModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;
            FillFormFields();// Заполнение полей формы выбранными значениями
        }
        private void FillFormFields()
        {
            if (_selectedItem != null)
            {// Заполнение полей формы значениями выбранного элемента
                name_fine.Text = _selectedItem.Name;
                value_fine.Text = _selectedItem.Value;
                status_fine.Text = _selectedItem.Status;
                state_number.ItemsSource = repository.GetList();
                var result = new List<TransportViewModel>();// Заполнение списка автомобилей в окне
                foreach (TransportViewModel state in state_number.ItemsSource)
                {
                    if (_selectedItem.Transport.StateNumber == state.StateNumber)
                    {
                        state_number.SelectedItem = state;// Установка выбранного элемента в списке автомобилей
                        break;
                    }
                    else
                    {
                        result.Add(state);
                    }
                    state_number.SelectedItem = result[0];// Установка первого элемента списка автомобилей по умолчанию
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TransportViewModel selected = state_number.SelectedItem as TransportViewModel;// Получение выбранного транспорт
                FineEntity entity = new FineEntity // Создание объекта с данными сотрудника
                {
                    Name = name_fine.Text,
                    Value = value_fine.Text,
                    Status = status_fine.Text,
                    TransportID = selected.ID// Запись ID выбранного транспорта
                };


                if (_selectedItem != null)
                {
                    entity.ID = _selectedItem.ID;
                    _repository.Update(entity);// Обновление данных штрафа
                }
                else
                {
                    _repository.Add(entity);// Добавление нового штрафа
                }

                MessageBox.Show("Запись успешно сохранена.");// Вывод сообщения об успешном сохранении  
                FineAdminWindow fineWindow = new FineAdminWindow();
                fineWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// Вывод сообщения об ошибке
            }
        }

    }
}
