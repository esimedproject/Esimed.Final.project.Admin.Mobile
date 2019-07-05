using AppEmploye.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEmploye.DataServices.Interface
{
    public interface IContactServices
    {
       List<Contacts> GetAllContactsByUser(int id);

        bool Create(Contacts contacts);
    }
}
