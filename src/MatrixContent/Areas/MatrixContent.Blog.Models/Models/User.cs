using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixContent.Blog.Models
{
    public class User
    {
        public string DisplayName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Title { get; set; }
        public string Zipcode { get; set; }
        public bool IsEmailPublic { get; set; }
        public bool IsPhonePublic { get; set; }
        public string IconPath { get; set; }

        public DateTime Brithday { get; set; }

        public ICollection<SocialAccount> SocialAccounts { get; set; }
    }   
}
