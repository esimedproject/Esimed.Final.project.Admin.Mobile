using AppEmploye.ViewModels.Base;

namespace AppEmploye.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public UserViewModel UsersModelView { get; set; }
        public MagazineViewModel MagazineModelView { get; set; }
        public MainViewModel(UserViewModel userview, MagazineViewModel magview )
        {
            this.UsersModelView = userview;
            this.MagazineModelView = magview;
        }
    }
}
