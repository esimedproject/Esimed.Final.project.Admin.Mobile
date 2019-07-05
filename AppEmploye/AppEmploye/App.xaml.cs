using AppEmploye.Services.Interfaces;
using AppEmploye.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppEmploye
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        private Task InitNavigation()
        {
            try
            {
                var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();

                return navigationService.InitializeAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
