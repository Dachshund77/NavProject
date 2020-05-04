using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mobile
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new View.SignupView());
        }

        void CheckUser(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new View.Welcome();
        }
    }
}
