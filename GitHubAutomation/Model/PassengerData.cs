using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Model
{
    public class PassengerData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BirthDay { get; set; }
        public string BirthMonth { get; set; }
        public string BirthYear { get; set; }
        public string DocNum { get; set; }
        public string DocDay { get; set; }
        public string DocMonth { get; set; }
        public string DocYear { get; set; }

        public PassengerData(string lastname, string firstname, string birthday, string birthmonth, string birthyear, string docnum, string docday, string docmonth, string docyear)
        {
            this.LastName = lastname;
            this.FirstName = firstname;
            this.BirthDay = birthday;
            this.BirthMonth = birthmonth;
            this.BirthYear = birthyear;
            this.DocNum = docnum;
            this.DocYear = docyear;
            this.DocMonth = docmonth;
            this.DocDay = docday;
        }
    }
}
