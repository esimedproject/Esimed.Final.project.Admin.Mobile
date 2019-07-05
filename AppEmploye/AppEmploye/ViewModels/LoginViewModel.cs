using AppEmploye.DataServices;
using AppEmploye.Helper;
using AppEmploye.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppEmploye.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private string mail;
        private string password;

        public string Mail
        {
            get { return mail; }
            set { mail = value; RaisePropertyChanged(() => Mail); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(() => Password); }
        }


        public ICommand ConnectCommand => new Command(Connect);


        private void Connect()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                try
                {
                    Admins admin = new AdminsServices().Connexion(new Admins { Email = mail, Password = password });
                    if(admin != null)
                    {
                        Constant.Admin = admin;
                        NavigationService.NavigateToAsync<MainViewModel>();
                    }
                }
                catch (Exception ex)
                {
                    DialogService.ShowAlertAsync("Erreur lors du login, vérifiez vos champs", "", "ok");
                    
                }
                finally
                {
                    IsBusy = false;
                }

            }
        }
    }
}
