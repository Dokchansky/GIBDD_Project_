﻿using System;
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Hide();
            PersonalAdminWindow personalWindow = new PersonalAdminWindow();
            personalWindow.Show();
        }
    }
}
