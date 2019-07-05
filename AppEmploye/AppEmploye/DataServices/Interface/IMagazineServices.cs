using AppEmploye.Models;
using System.Collections.Generic;

namespace AppEmploye.DataServices.Interface
{
    public interface IMagazineServices
    {
        Magazines Get(int id);

        List<Magazines> GetAll();

        bool Update(Magazines magazine);

        bool Create(Magazines magazine);

        List<Magazines> GetAllMagazinesOfCustomer(int id);

    }
}
