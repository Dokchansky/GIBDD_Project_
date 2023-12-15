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
        public AddFineWindow()
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
            FineAdminWindow fineadmWindow = new FineAdminWindow();
            fineadmWindow.Show();
            Close();
        }
        private FineViewModel _selectedItem = null;// Переменная для хранения выбранного элемента
        private FineRepository _repository = new FineRepository();// Репозиторий для работы с программами занятий
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
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FineEntity entity = new FineEntity();// Создание объекта с данными программ занятий
                entity.Name = name_fine.Text;
                entity.Value = value_fine.Text;
                entity.Status = status_fine.Text;


                if (_selectedItem != null)
                {
                    entity.ID = _selectedItem.ID;
                    _repository.Update(entity);// Обновление данных программы занятий
                }
                else
                {
                    _repository.Add(entity);// Добавление новой программы занятий
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
