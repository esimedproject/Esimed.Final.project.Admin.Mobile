using AppEmploye.Models;

namespace AppEmploye.Helper
{
    public static class Constant
    {
        public static Admins Admin { get; set; }
        public const string BaseUrl = "https://apimobile.conveyor.cloud/api/";
        public const string EmployeUrl = @"Admins/";
        public const string MagazineUrl = @"Magazines/";
        public const string ClientUrl = @"Users/";
        public const string ContactsUrl = @"Contacts/";
        public const string ByUserUrl = @"ByUser/";

    }
}
