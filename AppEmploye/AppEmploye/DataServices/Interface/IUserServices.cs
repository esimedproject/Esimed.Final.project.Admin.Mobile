using AppEmploye.Models;
using System.Collections.Generic;

namespace AppEmploye.DataServices.Interface
{
    public interface IClientServices
    {
        Users Get(int id);

        List<Users> GetAll();
    }
}
