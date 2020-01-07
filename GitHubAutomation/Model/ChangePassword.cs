using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Model
{
    public class ChangePasssword
    {
        public string NewPassword { get; set; }
        public string RepeatNewPassword { get; set; }

        public ChangePasssword(string newPassword, string repeatNewPassword)
        {
            this.NewPassword = newPassword;
            this.RepeatNewPassword = repeatNewPassword;
        }
    }
}
