using AppEmploye.DataServices;
using AppEmploye.DataServices.Interface;
using AppEmploye.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppEmploye.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private ObservableCollection<Users> user;


        public ObservableCollection<Users> User
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

        public UserViewModel()
        {

            User = new ObservableCollection<Users>(new UsersServices().GetAll());
        }


        public ICommand GoToClient => new Command<Users>(GetClient);

        public ICommand CreateHistorique => new Command(Create);

        private async void Create()
        {
            await NavigationService.NavigateToAsync<ContactViewModel>();
        }
        private async void GetClient(Users usert)
        {
            await NavigationService.NavigateToAsync<UserDetailViewModel>(usert.Id);

        }
    }
}
