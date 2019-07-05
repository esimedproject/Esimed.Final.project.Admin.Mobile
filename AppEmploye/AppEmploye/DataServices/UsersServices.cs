using AppEmploye.DataServices.Interface;
using AppEmploye.Helper;
using AppEmploye.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AppEmploye.DataServices
{
    public class UsersServices : IClientServices
    {
        private readonly RestClient client;
        public UsersServices()
        {
            client = new RestClient(new Uri(Constant.BaseUrl+Constant.ClientUrl));
            client.AddDefaultHeader("Authorization", $"bearer {Constant.Admin.AuthentificationKey}");
        }
        public Users Get(int id)
        {
            RestRequest request = new RestRequest($"{id}") { Method = Method.GET };

            return client.Execute<Users>(request).Data;
        }

        public List<Users> GetAll()
        {
         
            RestRequest request = new RestRequest() { Method = Method.GET };

            return client.Execute<List<Users>>(request).Data;
           
        }

    }
}
