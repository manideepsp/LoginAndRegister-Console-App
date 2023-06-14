using BusinessObjects;
using DAL;
using System;

namespace BLL
{

    /// <summary>
    /// Business Logic Layer
    /// </summary>
    public class BusinessLogic
    {
        //Objects creation for Data Access
        private DataAccess dataOperation;
        public BusinessLogic()
        {
            dataOperation = new DataAccess();
        }

        /// <summary>
        /// Implements Login Functionality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Implements Logot Functionality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Logout(BusinessObj obj)
        {
            Console.WriteLine("You have successfully logged out !");
            obj = new BusinessObj();
            return "logout";
        }

        /// <summary>
        /// Implements Forgot password Functionality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string ForgotPassword(BusinessObj obj)
        {
            bool decision = false;
            if (obj.Password == obj.ConfirmPassword)
            {
                decision = dataOperation.UpdatePassword(obj.Password, obj.Username); //Returns true if operation is succesful, else false
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

        /// <summary>
        /// Implements Create User Functionality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string CreateUser(BusinessObj obj)
        {
            bool flag = dataOperation.CheckIfPresent(obj.Username); //if username is present, return true, else false
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
