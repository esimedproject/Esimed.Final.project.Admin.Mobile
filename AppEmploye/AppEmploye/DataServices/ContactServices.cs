using AppEmploye.DataServices.Interface;
using AppEmploye.Helper;
using AppEmploye.Models;
using RestSharp;
using System;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace AppEmploye.DataServices
{
    public class ContactServices : IContactServices
    {
        private readonly RestClient client;
        public ContactServices()
        {
            client = new RestClient(new Uri($"{Constant.BaseUrl}{Constant.ContactsUrl}"));
            client.AddDefaultHeader("Authorization", $"bearer {Constant.Admin.AuthentificationKey}");


        }

        public List<Contacts> GetAllContactsByUser(int id)
        {
            RestRequest request = new RestRequest($"{Constant.ByUserUrl}{id}") { Method = Method.GET };
            var list = client.Get<List<Contacts>>(request).Data;
            return list;
        }

        public bool Create(Contacts contacts)
        {
            RestRequest request = new RestRequest() { Method = Method.POST};
            request.AddJsonBody(contacts);
            return client.Execute(request).StatusCode == System.Net.HttpStatusCode.Created;
        }
    }
}
