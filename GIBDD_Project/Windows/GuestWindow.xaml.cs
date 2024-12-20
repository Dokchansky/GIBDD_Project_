﻿using GIBDD_Project.Infrastructure.Consts;
using GIBDD_Project.Infrastructure.Database;
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
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        private GIBDDRepository _repository;
        public GuestWindow()
        {
            InitializeComponent();
            Title = "Окно гостя";
            _repository = new GIBDDRepository();
            GuestGrid.ItemsSource = _repository.GetList();
            userNameTextBox.Text = Application.Current.Resources[UserInfoConsts.UserName].ToString();
            roleTextBox.Text = Application.Current.Resources[UserInfoConsts.RoleName].ToString();
        }
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Hide();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }
    }
}
