using AppEmploye.DataServices.Interface;
using AppEmploye.Helper;
using AppEmploye.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AppEmploye.DataServices
{
    public class MagazinesServices : IMagazineServices
    {
        private readonly RestClient client;
        public MagazinesServices()
        {
            client = new RestClient(new Uri($"{Constant.BaseUrl}{Constant.MagazineUrl}"));
            client.AddDefaultHeader("Authorization", $"bearer {Constant.Admin.AuthentificationKey}");

        }

        public bool Create(Magazines magazine)
        {
            RestRequest request = new RestRequest() { Method = Method.POST };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(magazine);
            var response = client.Execute(request);
            return response.IsSuccessful;
        }

        public Magazines Get(int id)
        {
            RestRequest request = new RestRequest($"{id}") { Method = Method.GET };

            return client.Get<Magazines>(request).Data;
        }

        public List<Magazines> GetAll()
        {
            RestRequest request = new RestRequest() { Method = Method.GET };

            return client.Get<List<Magazines>>(request).Data;
        }

        public List<Magazines> GetAllMagazinesOfCustomer(int id)
        {
            RestRequest request = new RestRequest($"{id}") { Method = Method.GET };

            return client.Get<List<Magazines>>(request).Data;
        }

        public bool Update(Magazines magazine)
        {
            RestRequest request = new RestRequest($"{magazine.Id}") { Method = Method.PUT };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(magazine);
            var response = client.Execute(request);
            return response.IsSuccessful; 
        }
    }
}
