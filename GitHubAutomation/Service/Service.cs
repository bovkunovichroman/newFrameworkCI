using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubAutomation.Model;
using GitHubAutomation.Utils;
using GitHubAutomation.Tests;

namespace GitHubAutomation.Service
{
    public class Service
    {
        public static PassengerData WithPassengerDataProperties()
        {
            return new PassengerData
               (
                TestDataReader.GetData("LastName"),
                TestDataReader.GetData("FirstName"),
                TestDataReader.GetData("BirthDay"),
                TestDataReader.GetData("BirthMonth"),
                TestDataReader.GetData("BirthYear"),
                TestDataReader.GetData("DocNum"),
                TestDataReader.GetData("DocDay"),
                TestDataReader.GetData("DocMonth"),
                TestDataReader.GetData("DocYear")
                );
        }
        public static PassengerData WithPassengerDataPropertiesWithoutName()
        {
            return new PassengerData
               (
                TestDataReader.GetData("LastName"),
                TestDataReader.GetData("FirstNameNull"),
                TestDataReader.GetData("BirthDay"),
                TestDataReader.GetData("BirthMonth"),
                TestDataReader.GetData("BirthYear"),
                TestDataReader.GetData("DocNum"),
                TestDataReader.GetData("DocDay"),
                TestDataReader.GetData("DocMonth"),
                TestDataReader.GetData("DocYear")
                );
        }
        public static ChangePasssword WithUserPropertiesRepeatNewPassword()
        {
            return new ChangePasssword
                (
                TestDataReader.GetData("NewPassword"),
                TestDataReader.GetData("RepeatNewPassword")
                );
        }
        public static ChangePasssword WithUserPropertiesWithoutRepeat()
        {
            return new ChangePasssword
                (
                TestDataReader.GetData("NewPassword"),
                TestDataReader.GetData("NewPasswordNull")
                );
        }
        public static Registration WithPropertiesAboutRegistration()
        {
            return new Registration
                (
                TestDataReader.GetData("FirstName"),
                TestDataReader.GetData("LastName"),
                TestDataReader.GetData("Email"),
                TestDataReader.GetData("Password")
                );
        }

        public static SearchResultWithoutDate WithSearchResultWithoutDateProperties()
        {
            return new SearchResultWithoutDate
                (
                TestDataReader.GetData("InputSityTo")
                );
        }

        public static SignIn WithUserPropertiesForSignIn()
        {
            return new SignIn
                (
                TestDataReader.GetData("MemberId"),
                TestDataReader.GetData("Password")
                );
        }
    }
}
