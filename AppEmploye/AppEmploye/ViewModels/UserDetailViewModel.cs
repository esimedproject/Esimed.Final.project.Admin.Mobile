using AppEmploye.DataServices.Interface;
using AppEmploye.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppEmploye.ViewModels
{
    public class UserDetailViewModel : ViewModelBase
    {
        private readonly IClientServices clientservice;
        private readonly IContactServices contactservice;

        private Users user;

        private ObservableCollection<Contacts> contacts;

        public Users User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                RaisePropertyChanged(() => User);
            }
        }

        public ObservableCollection<Contacts> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = value;
                RaisePropertyChanged(() => Contacts);
            }
        }

        public UserDetailViewModel(IClientServices services, IContactServices contactServices)
        {
            clientservice = services;
            contactservice = contactServices;
            

        }
        public ICommand CheckAbonnements => new Command(GoToAbonnements);

        private async void GoToAbonnements()
        {
            await NavigationService.NavigateToAsync<UserMagazineListViewModel>(User.Id);
        }
        public override Task InitializeAsync(object navigationData)
        {
            int idClient = (int)navigationData;
            //Get Client using DataServices
            User = clientservice.Get(idClient);
            Contacts = new ObservableCollection<Contacts>(contactservice.GetAllContactsByUser(idClient));
            return base.InitializeAsync(navigationData);
        }
    }
}
