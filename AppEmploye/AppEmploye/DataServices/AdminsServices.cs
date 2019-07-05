using AppEmploye.DataServices.Interface;
using AppEmploye.Helper;
using AppEmploye.Models;
using RestSharp;
using System;
using RestSharp.Serialization.Json;

namespace AppEmploye.DataServices
{
    public class AdminsServices : IAdminServices
    {
        private readonly RestClient client;
        public AdminsServices()
        {
            client = new RestClient(new Uri($"{Constant.BaseUrl}{Constant.EmployeUrl}"));
      
        }
        public Admins Connexion(Admins employe)
        {
            RestRequest request = new RestRequest("AuthenticateAdmin") { Method = Method.POST };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(employe);
            var content = client.Execute(request).Content;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Admins>(content);
        }

        public Admins Get(int id)
        {
            RestRequest request = new RestRequest($"{id}") { Method = Method.GET };

            return client.Get<Admins>(request).Data;
        }
    }
}
