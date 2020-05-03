using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeDetail : ContentPage
    {
        ZXingScannerPage scanPage;
        public WelcomeDetail()
        {
            InitializeComponent();
        }

        private async void StartScanner(System.Object sender, System.EventArgs e)
        {
            //App.Current.MainPage = new View.Scanner();

            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                //Do something with the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("Scanned to basket", result.Text, "OK");
                });
            };

            await Navigation.PushAsync(scanPage);


        }

    }
}
