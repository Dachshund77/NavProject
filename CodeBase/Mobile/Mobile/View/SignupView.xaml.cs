using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class SignupView : ContentPage
    {
        public SignupView()
        {
            InitializeComponent();
        }

        void BackToLogin(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LoginView());
        }
    }
}
