using BusinessObjects;
using DAL;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace BLL
{
    public class BusinessLogic
    {
        //DataAccess dataOperation = new DataAccess();
        //BusinessLogic operation = new BusinessLogic();
        private DataAccess dataOperation;
        public BusinessLogic()
        {
            dataOperation = new DataAccess();
        }

        public string Login(BusinessObj obj)
        {
            bool flag = dataOperation.CheckIfPresent(obj.Username, obj.Password);
            if(flag==true)
            {
                Console.WriteLine($"Welcome {obj.Username} !\npress 1 to logout");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    return Logout(obj);
                }
                return "fail";
            }
            else
            {
                Console.WriteLine("The entered username or password is wrong, try again.\n");
                obj = new BusinessObj();
                return "fail";
            }

        }
        public string Logout(BusinessObj obj)
        {
            Console.WriteLine("You have successfully logged out !");
            obj = new BusinessObj();
            return "success";
        }
        public string ForgotPassword(BusinessObj obj)
        {
            bool decision = false;
            if (obj.Password == obj.ConfirmPassword)
            {
                decision = dataOperation.UpdatePassword(obj.Password, obj.Username);
            }
            if(decision == false)
            {
                obj = new BusinessObj();
                return "fail";
            }
            else
            {
                return "success";
            }
        }
        public string CreateUser(BusinessObj obj)
        {
            bool flag = dataOperation.CheckIfPresent(obj.Username);
            if(flag == true)
            {
                Console.WriteLine("User Already Exist !"+
                    "/nPress 1 to Login : ");
                int decision = Convert.ToInt32(Console.ReadLine());
                if(decision == 1 )
                {
                    obj = new BusinessObj();
                    return "success";
                }
                return "fail";
            }
            else
            {
                dataOperation.CreateNewUser(obj);
                return "success";
            }
        }
    }
}
