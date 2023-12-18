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
    /// Логика взаимодействия для FineAdminWindow.xaml
    /// </summary>
    public partial class FineAdminWindow : Window
    {
        private FineRepository _repository;
        public FineAdminWindow()
        {
            InitializeComponent();
            Title = "Список штрафов";
            _repository = new FineRepository();
            FineGrid.ItemsSource = _repository.GetList();
        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide();
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Hide();
            AddFineWindow addFineWindow = new AddFineWindow();
            addFineWindow.Show();
            Close();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reportManager = new ReportManager();
                var data = reportManager.GenerateReport(FineGrid.ItemsSource as List<FineViewModel>);

                var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Штрафы_{DateTime.Now.ToShortDateString()}.xlsx");
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
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (FineGrid.SelectedItem != null)
            {
                var qrManager = new QRManager();
                var qrCodeImage = qrManager.Generate(FineGrid.SelectedItem);
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
                FineGrid.ItemsSource = _repository.GetList(); // Показать все элементы, если запрос пуст.
            }

            else
            {
                List<FineViewModel> searchResult = _repository.Search(search);// Выполнить поиск по запросу.
                FineGrid.ItemsSource = searchResult;// Отобразить результаты поиска.
            }
        }
        private void UpdateGrid()
        {
            FineGrid.ItemsSource = _repository.GetList();// Установка источника данных таблицы из репозитория.
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли штраф для удаления.
            if (FineGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран объект для удаления");
                return;
            }
            // Получение выбранного объекта из таблицы
            var item = FineGrid.SelectedItem as FineViewModel;
            // Проверка, удалось ли получить данные о штрафе
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
                return;
            }
            // Удаление штрафа из репозитория и обновление данных в таблице.
            _repository.Delete(item.ID);
            UpdateGrid();
        }
        private void Change(object sender, RoutedEventArgs e)
        { // Проверка наличия выбранного объекта в таблице.
            if (FineGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран объект для изменения");
                return;
            }
            // Открытие окна редактирования для выбранного объекта и обновление данных в таблице.
            var userCard = new AddFineWindow(FineGrid.SelectedItem as FineViewModel);
            userCard.ShowDialog();
            UpdateGrid();
        }

    }
}
