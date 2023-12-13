﻿using GIBDD_Project.Infrastructure.Database;
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





        }
        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Search(object sender, RoutedEventArgs e)
        {
            string search = find.Text;
            if (string.IsNullOrEmpty(search))
            {
                FineGrid.ItemsSource = _repository.GetList();
            }
            else
            {
                //List<UserViewModel> searchResult = _repository.Search(search);
                //FineGrid.ItemsSource = searchResult;
            }
        }
    }
}
