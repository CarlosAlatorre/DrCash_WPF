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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoctorCashWpf.Views
{
    /// <summary>
    /// Interaction logic for Authentication.xaml
    /// </summary>
    public partial class Authentication : UserControl
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private userService user = new userService();
        private BrushConverter brushConverter = new BrushConverter();

        private void authentification()
        {
            var userData = user.authentication(txtbox_username.Text, txtbox_password.Password.ToString());

            if (userData != null)
            {
                labelError.Content = "";
                userInformation.user = userData;
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null, null);
            }
            else
            {
                //Mensaje de error por datos incorrectos
                //poner que no se encontro el usuario       
                labelError.Content = "                    Verify Data"+"\n"+
                                     "Username or Password is Incorrect";
            }
        }

        private void verify()
        {
            if (txtbox_username.Text == "")
            {
                txtbox_username.Focus();
               
                txtbox_username.Foreground = (Brush)brushConverter.ConvertFrom("#e74c3c");
                labelError.Content = "Complete the fields marked";
            }
            else if (txtbox_password.Password.ToString() == "")
            {
                txtbox_password.Focus();

                txtbox_password.Foreground = (Brush)brushConverter.ConvertFrom("#e74c3c");
                labelError.Content = "Complete the fields marked";
            }
            else
            {
                authentification();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            verify();      
        }

        private void authentification_KeyUp(object sender, KeyEventArgs e)
        {
            labelError.Content = "";
            if (e.Key == Key.Enter)
            {
                verify();
            }
        }
    }
}
