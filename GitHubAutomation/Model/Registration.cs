using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Model
{
    public class Registration
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Registration(string lastname, string firstname, string email, string password)
        {
            this.LastName = lastname;
            this.FirstName = firstname;
            this.Email = email;
            this.Password = password;
         
        }
    }
}
