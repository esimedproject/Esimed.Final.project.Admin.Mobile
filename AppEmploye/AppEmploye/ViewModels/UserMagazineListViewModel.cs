using AppEmploye.DataServices.Interface;
using AppEmploye.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AppEmploye.ViewModels
{
    public class UserMagazineListViewModel : ViewModelBase
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

        public UserMagazineListViewModel(IMagazineServices magazineServices)
        {
            this.magazineServices = magazineServices;
        }

        public override Task InitializeAsync(object navigationData)
        {
            int id = (int)navigationData;
            Magazines = new ObservableCollection<Magazines>(magazineServices.GetAllMagazinesOfCustomer(id));
            return base.InitializeAsync(navigationData);
        }
    }
}
