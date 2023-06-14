using BusinessObjects;
using DAL;
using System;

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
            if (flag == true)
            {
                Console.WriteLine($"Welcome {obj.Username} !"+
                    "\n\n press c to change your password." +
                    "\n\n press any other key to logout\n");

                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.C)
                {
                    return "changePassword";
                }
            }
            obj = new BusinessObj();
            return "fail";
        }

        public string Logout(BusinessObj obj)
        {
            Console.WriteLine("You have successfully logged out !");
            obj = new BusinessObj();
            return "logout";
        }
        public string ForgotPassword(BusinessObj obj)
        {
            bool decision = false;
            if (obj.Password == obj.ConfirmPassword)
            {
                decision = dataOperation.UpdatePassword(obj.Password, obj.Username);
            }
            if (decision == false)
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
            if (flag == true)
            {
                Console.WriteLine("User Already Exist !");
                obj = new BusinessObj();
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
