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
    /// Логика взаимодействия для CarsWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        private TransportRepository _transportRepository;
        private TransportViewModel _viewTransportModel;
        public CarsWindow()
        {
            InitializeComponent();
            Title = "Список автомобилей";
            _transportRepository = new TransportRepository();
            state_number.ItemsSource = _transportRepository.GetList();
        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void UpdateGrid()
        {
            if (_viewTransportModel != null)
            {
                var selectedNumber = _transportRepository.GetByTransportId(_viewTransportModel.ID);
                carGrid.ItemsSource = selectedNumber;



            }
            else
            {
                carGrid.ItemsSource = null;
            }
        }

        private void state_number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewTransportModel = state_number.SelectedItem as TransportViewModel;
            UpdateGrid();
        }
    }
}
