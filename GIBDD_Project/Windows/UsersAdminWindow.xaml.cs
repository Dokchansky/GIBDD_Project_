using GIBDD_Project.Infrastructure.Database;
using GIBDD_Project.Infrastructure.QR;
using GIBDD_Project.Infrastructure.Report;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для UsersAdminWindow.xaml
    /// </summary>
    public partial class UsersAdminWindow : Window
    {
        // Репозиторий пользователей для взаимодействия с данными пользователей 
        private UserRepository userRepository;
        // Модель-представление пользователя для работы с данными  
        private UserViewModel userViewModel;


        public UsersAdminWindow()
        {
            InitializeComponent(); // Инициализирует компоненты окна 
            Title = "Список пользователей"; // Устанавливает заголовок окна 
            userRepository = new UserRepository(); // Создает экземпляр репозитория 

            userGrid.ItemsSource = userRepository.GetList(); // Задает источник данных для списка пользователей 
            UpdateGrid(); // Обновляет данные в таблице пользователей 
        }

        // Обработчик события для кнопки "Меню" - возврат в окно админа 
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide(); // Скрывает текущее окно 
            AdminWindow adminWindow = new AdminWindow(); // Создает новое окно администратора 
            adminWindow.Show(); // Показывает окно админа 
            Close(); // Закрывает текущее окно 
        }
        // Обработчик события для кнопки "Добавить" - открытие окна добавления пользователя 
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Hide(); // Скрывает текущее окно 
            AddUserWindow addUserWindow = new AddUserWindow(); // Создает окно для добавления пользователя 
            addUserWindow.Show(); // Отображает окно для добавления пользователя 
        }

        // Метод для экспорта списка пользователей в файл Excel 
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reportManager = new ReportManager();
                var data = reportManager.GenerateReport(userGrid.ItemsSource as List<UserViewModel>);

                var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Пользователи_{DateTime.Now.ToShortDateString()}.xlsx");
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    stream.Write(data, 0, data.Length);
                }
                MessageBox.Show("Выгрузка успешна");
            }
            catch
            {
                MessageBox.Show("Выгрузка неуспешна");
            }

        }
        // Метод для генерации QR-кода для выбранного пользователя 
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (userGrid.SelectedItem != null)
            {
                var qrManager = new QRManager();
                var qrCodeImage = qrManager.Generate(userGrid.SelectedItem);
                var qrWindow = new QRWindow();
                qrWindow.qrImage.Source = qrCodeImage;
                qrWindow.Show();
            }
            else
            {
                MessageBox.Show("Объект не выбран");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string search = find.Text;
            if (string.IsNullOrEmpty(search))
            {
                userGrid.ItemsSource = userRepository.GetList(); // Показать все элементы, если запрос пуст.
            }

            else
            {
                List<UserViewModel> searchResult = userRepository.Search(search);// Выполнить поиск по запросу.
                userGrid.ItemsSource = searchResult;// Отобразить результаты поиска.
            }
        }
        private void UpdateGrid()
        {
            userGrid.ItemsSource = userRepository.GetList();// Установка источника данных таблицы из репозитория.
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли сотрудник для удаления.
            if (userGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран объект для удаления");
                return;
            }
            // Получение выбранного объекта из таблицы
            var item = userGrid.SelectedItem as UserViewModel;
            // Проверка, удалось ли получить данные о сотруднике
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
                return;
            }
            // Удаление сотрудника из репозитория и обновление данных в таблице.
            userRepository.Delete(item.ID);
            UpdateGrid();
        }
    }
}
