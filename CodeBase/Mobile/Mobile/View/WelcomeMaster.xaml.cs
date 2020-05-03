using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeMaster : ContentPage
    {
        public ListView ListView;

        public WelcomeMaster()
        {
            InitializeComponent();

            BindingContext = new WelcomeMasterViewModel();
            ListView = MenuItemsListView;
        }

        class WelcomeMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<WelcomeMenuItem> MenuItems { get; set; }

            public WelcomeMasterViewModel()
            {
                MenuItems = new ObservableCollection<WelcomeMenuItem>(new[]
                {
                    new WelcomeMenuItem { Id = 0, Icon="logoutnew.png", Title = "Logout", TargetType=typeof(LoginView) },
                });

        }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
