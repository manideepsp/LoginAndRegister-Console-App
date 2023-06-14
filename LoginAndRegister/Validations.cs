using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace LoginAndRegister
{
    public class Validations
    {
        public bool ValidatePassword(string a, string b)
        {
            if(a.Equals(b)) return true;
            else return false;
        }
        public bool ValidateMobile(string mobileNumber)
        {
            if(mobileNumber.Count() == 10 && IsDigitsOnly(mobileNumber))
            {
                return true;
            }
            else return false;
        }

        //Logic to check string contains only digits
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        //if it contains returns true, else false
        public bool ValidateUsername(string username, DataAccess dataOperation)
        {
            return dataOperation.CheckIfPresent(username);
        }
    }
}
