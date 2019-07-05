using AppEmploye.DataServices.Interface;
using AppEmploye.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppEmploye.ViewModels
{
    public class MagazineViewModel : ViewModelBase
    {
        private readonly IMagazineServices magazineServices;
        private ObservableCollection<Magazines> magazines;


        public ObservableCollection<Magazines> Magazines
        {
            get
            {
                return magazines;
            }
            set
            {
                magazines = value;
                RaisePropertyChanged(() => Magazines);
            }
        }

        public MagazineViewModel(IMagazineServices magazineServices)
        {
            this.magazineServices = magazineServices;
            magazines = new ObservableCollection<Magazines>(magazineServices.GetAll());
        }


        public ICommand GoToMagazine => new Command<Magazines>(GetMagazine);

        public ICommand CreateMagazine => new Command(Create);


        private async void Create()
        {
            await NavigationService.NavigateToAsync<MagazineDetailViewModel>();
        }
        private async void GetMagazine(Magazines magazine)
        {
            await NavigationService.NavigateToAsync<MagazineDetailViewModel>(magazine.Id);

        }
    }
}
