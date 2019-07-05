using AppEmploye.DataServices;
using AppEmploye.DataServices.Interface;
using AppEmploye.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppEmploye.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {

        private readonly IClientServices clientServices;
        private readonly IContactServices contactServices;
        private string meanOfContact;
        private string subject;

        private Users user;

        private ObservableCollection<Users> users;


        public ObservableCollection<Users> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                RaisePropertyChanged(() => Users);
            }
        }
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
        public string MeanOfContact
        {
            get { return meanOfContact; }
            set { meanOfContact = value; RaisePropertyChanged(() => MeanOfContact); }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; RaisePropertyChanged(() => Subject); }
        }

        public ContactViewModel(IClientServices clientServices, IContactServices contactServices)
        {
            this.clientServices = clientServices;
            this.contactServices = contactServices;
            User = new Users();
            Users = new ObservableCollection<Users>(new UsersServices().GetAll());
        }

        public ICommand CreateHistorique => new Command(Create);


        private async void Create()
        {
            if (contactServices.Create(new Contacts { Means_of_contact = meanOfContact, Subject = subject, Date = DateTime.Now, UserContactID = user.Id })) ;
            {
                await DialogService.ShowAlertAsync("Contact créé, redirection...", "", "Ok");
                await NavigationService.NavigateToAsync<MainViewModel>();
            }
        }
    }
}
