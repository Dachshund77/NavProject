﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // When done with dev, place back to this mainPage
            MainPage = new NavigationPage(new LoginView());

            // MainPage = new View.WelcomeView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
