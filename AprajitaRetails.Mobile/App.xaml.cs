using AprajitaRetails.Mobile.Services.Obsolute;
using AprajitaRetails.Mobile.Views;
using Application = Microsoft.Maui.Controls.Application;

namespace AprajitaRetails.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NavigationService>();
            Routing.RegisterRoute(typeof(ItemDetailPage).FullName, typeof(ItemDetailPage));
            Routing.RegisterRoute(typeof(NewItemPage).FullName, typeof(NewItemPage));
            MainPage = new MainPage();
        }
    }
}