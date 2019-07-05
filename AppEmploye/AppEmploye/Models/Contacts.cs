using System;

namespace AppEmploye.Models
{
    public class Contacts
    {
        public string Subject { get; set; }
        public string Means_of_contact { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string Comment { get; set; }
        public int UserContactID { get; set; }
    }
}
