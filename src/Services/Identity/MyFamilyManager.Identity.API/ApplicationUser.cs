using Microsoft.AspNetCore.Identity;

namespace MyFamilyManager.Identity.API
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhonePrimary { get; set; }
        public string PhoneSecondary { get; set; }
    }
}
