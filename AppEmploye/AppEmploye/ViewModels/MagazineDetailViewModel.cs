using AppEmploye.DataServices.Interface;
using AppEmploye.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppEmploye.ViewModels
{
    public class MagazineDetailViewModel : ViewModelBase
    {
        private readonly IMagazineServices magazineServices;
        private Magazines magazine;
        private string btText;
        public Magazines Magazine
        {
            get
            {
                return magazine;
            }
            set
            {
                magazine = value;
                RaisePropertyChanged(() => Magazine);
            }
        }
        public string BtText
        {
            get
            {
                return btText;
            }
            set
            {
                btText = value;
                RaisePropertyChanged(() => BtText);
            }
        }
        public MagazineDetailViewModel(IMagazineServices magazineServices)
        {
            this.magazineServices = magazineServices;
        }
        public ICommand UpdateMagazine => new Command(Update);

        private async void Update()
        {
            //Call MagazineService
            if(magazine.Id == 0)
            {
                if (magazineServices.Create(Magazine))
                {
                    await DialogService.ShowAlertAsync("Création du magazine avec succès", "", "Ok");
                    Magazine = new Magazines();
                    await NavigationService.NavigateToAsync<MainViewModel>(); 

                }
            }
            else if(magazineServices.Update(Magazine))
            {
                await DialogService.ShowAlertAsync("Enregistrement effectué avec succés", "", "Ok");
            }
        }
        public override Task InitializeAsync(object navigationData)
        {
            Magazine = new Magazines();
            BtText = "Créer magazine";
            if (navigationData != null)
            {
                int idMagazine = (int)navigationData;
                Magazine = magazineServices.Get(idMagazine);
                BtText = "Enregistrer changement";
            }
            //Get Magazine using Id.
            return base.InitializeAsync(navigationData);
        }
    }
}
