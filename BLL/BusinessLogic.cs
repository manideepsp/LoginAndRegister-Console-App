using BusinessObjects;
using DAL;
using System;

namespace BLL
{
    public class BusinessLogic
    {
        //public BusinessLogic(BusinessObj obj)
        //{
        //    string username = obj.Username;
        //    string password = obj.Password;
        //    string confirmPassword = obj.ConfirmPassword;
        //    string firstName = obj.FirstName;
        //    string lastName = obj.LastName;
        //    string email = obj.Email;
        //    string mobile = obj.Mobile;
        //}

        DataAccess dataOperation = new DataAccess();
        BusinessLogic operation = new BusinessLogic();

        public string Login(BusinessObj obj)
        {
            bool flag = dataOperation.CheckIfPresent(obj.Username, obj.Password);
            if(flag==true)
            {
                Console.WriteLine($"Welcome {obj.Username} !/npress 1 to logout");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    return operation.Logout(obj);
                }
                return "fail";
            }
            else
            {
                Console.WriteLine("The entered username or password is wrong, try again./n");
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
            if(obj.Password == obj.ConfirmPassword)
            {
                dataOperation.UpdatePassword(obj.Password, obj.Username);
                return "success";
            }
            else
            {
                obj = new BusinessObj();
                return "fail";
            }
        }
        public string CreateUser(BusinessObj obj)
        {
            //BusinessLogic operation = new BusinessLogic();
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


        //public void menu(BusinessObj obj)
        //{
        //    Console.WriteLine("/nEnter: " +
        //        "/n* To Login enter 1"+
        //        "/* To Register As new user enter 2"+
        //        "/n* If you forgot you password enter 3"+
        //        "* To exit enter 0\"");
        //    switch (inp)
        //}
    }
}
