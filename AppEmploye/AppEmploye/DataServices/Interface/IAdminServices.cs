using AppEmploye.Models;

namespace AppEmploye.DataServices.Interface
{
    public interface IAdminServices
    {
        Admins Get(int id);

        Admins Connexion(Admins Admin);

    }
}
