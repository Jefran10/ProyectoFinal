﻿using ProyectoFinal.View;

namespace ProyectoFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
