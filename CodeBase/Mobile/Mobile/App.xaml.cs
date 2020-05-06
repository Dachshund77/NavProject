using Mobile.Mocks;
using Mobile.Services;
using System;
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


            //Registering of services
#if DEBUG
            RegisterMockServices();
#else
            RegisterRealServices();
#endif
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

        private void RegisterRealServices() {
            DependencyService.Register<IHttpAuthService, HttpAuthService>();
            DependencyService.Register<IHttpBasketsService, HttpBasketsService>();
            DependencyService.Register<IHttpProductsService, HttpProductsService>();
            DependencyService.Register<IHttpTransactionsService, HttpTransactionsService>();
            DependencyService.Register<IHttpUsersService, HttpUsersService>();
        }

        private void RegisterMockServices()
        {
            DependencyService.Register<IHttpAuthService, HttpAuthServiceMock>();
            DependencyService.Register<IHttpBasketsService, HttpBasketsServiceMock>();
            DependencyService.Register<IHttpProductsService, HttpProductsServiceMock>();
            DependencyService.Register<IHttpTransactionsService, HttpTransactionsServiceMock>();
            DependencyService.Register<IHttpUsersService, HttpUsersServiceMock>();
        }
    }
}
