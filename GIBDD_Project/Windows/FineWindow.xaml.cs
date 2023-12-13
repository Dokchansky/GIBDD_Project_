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
using GIBDD_Project.Infrastructure.Mappers;

namespace GIBDD_Project.Windows
{
    /// <summary>
    /// Логика взаимодействия для FineWindow.xaml
    /// </summary>
    public partial class FineWindow : Window
    {
        private FineRepository _repository;
        private TransportRepository _transportRepository;
        private TransportViewModel _viewTransportModel;

        public FineWindow()
        {
            InitializeComponent();
            Title = "Список штрафов";
            _repository = new FineRepository();
            //FineGrid.ItemsSource = _repository.GetList();
            _transportRepository = new TransportRepository();
            state_number.ItemsSource = _transportRepository.GetList();




        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void state_number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewTransportModel = state_number.SelectedItem as TransportViewModel;
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            if (_viewTransportModel != null)
            {
                var selectedNumber = _repository.GetByFineId(_viewTransportModel.ID);
                FineGrid.ItemsSource = selectedNumber;



            }
            else
            {
                FineGrid.ItemsSource = null;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
