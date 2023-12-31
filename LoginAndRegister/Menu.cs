﻿using BLL;
using BusinessObjects;
using DAL;
using System;

namespace LoginAndRegister
{
    public class Menu
    {

        /// <summary>
        /// Does operations described in menu
        /// </summary>
        /// <param name="redirect"></param>
        /// <param name="obj"></param>
        /// <param name="businessOperation"></param>
        /// <param name="dataOperation"></param>
        public void MenuOperation(int redirect, BusinessObj obj, BusinessLogic businessOperation, DataAccess dataOperation)
        {
            Validations val = new Validations();

            bool flag = false; //loop runs only when flag is true
            //loop runs until user exits application
            while (true)
            {
                //To exit application
                if (redirect == 0)
                {
                    Console.WriteLine("***** Closing app *****");
                    break;
                }

                //Login page
                else if (redirect == 1)
                {
                    Console.Write("\nWelcome to Login Page:" +
                                "\n\nEnter Username: ");
                    obj.Username = Console.ReadLine();

                    Console.Write("\nEnter Password: ");
                    obj.Password = Console.ReadLine();

                    string decision = businessOperation.Login(obj);
                    if (decision == "changePassword")
                    {
                        Console.WriteLine("\nRedirecting you to Forgot password / Change Password page.\n");
                        redirect = 3;
                    }
                    else
                    {
                        Console.WriteLine("\n Press 1 to create new user"
                                            + "\npress any other key to try again");

                        ConsoleKeyInfo cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.D1)
                        {
                            redirect = 2;
                        }
                        else
                        {
                            redirect = 1;
                        }
                    }
                }

                //Create new user
                else if (redirect == 2)
                {
                    Console.Write("Welcome to New User, enter your details to create new account:" +
                            "\n\nEnter Username: ");
                    obj.Username = Console.ReadLine();
                    flag = !val.ValidateUsername(obj.Username, dataOperation);

                    while (flag == false)
                    {
                        Console.WriteLine("Username already exists");
                        obj.Username = Console.ReadLine();
                        flag = !val.ValidateUsername(obj.Username, dataOperation); //Returns true if it is present in the data already
                    }

                    Console.Write("\nEnter First name: ");
                    obj.FirstName = Console.ReadLine();

                    Console.Write("\nEnter Last name: ");
                    obj.LastName = Console.ReadLine();

                    Console.Write("\nEnter email id: ");
                    obj.Email = Console.ReadLine();

                    Console.Write("\nEnter Mobile number: ");
                    obj.Mobile = Console.ReadLine();
                    flag = val.ValidateMobile(obj.Mobile);
                    while (flag == false)
                    {
                        Console.Write("\nEnter Mobile number Again with only 10 digits and only numbers: ");
                        obj.Mobile = Console.ReadLine();
                        flag = val.ValidateMobile(obj.Mobile); //returns true if its a valid mobile number
                    }

                    Console.Write("\nEnter Password: ");
                    obj.Password = Console.ReadLine();

                    Console.Write("\nConfirm Password: ");
                    obj.ConfirmPassword = Console.ReadLine();

                    flag = val.ValidatePassword(obj.Password, obj.ConfirmPassword);

                    while (flag == false)
                    {
                        Console.Write("Password and Confirm Password should match !" +
                            "\nEnter Again: ");
                        Console.Write("\nEnter Password: ");
                        obj.Password = Console.ReadLine();

                        Console.Write("\nConfirm Password: ");
                        obj.ConfirmPassword = Console.ReadLine();

                        flag = val.ValidatePassword(obj.Password, obj.ConfirmPassword); //returns true if passwords match
                    }

                    string decision = businessOperation.CreateUser(obj);
                    if (decision == "success")
                    {
                        redirect = 1;
                    }
                    else
                    {
                        Console.WriteLine("\n * User already exist, redirecting to login page...");
                        redirect = 1;
                    }
                }

                //Forgot Password also for change password
                else if (redirect == 3)
                {
                    Console.Write("\nWelcome to forgot password / Change password page:"
                        + "\n\nEnter username: ");
                    obj.Username = Console.ReadLine();

                    Console.Write("\nEnter Password: ");
                    obj.Password = Console.ReadLine();

                    Console.Write("\nConfirm Password: ");
                    obj.ConfirmPassword = Console.ReadLine();

                    flag = val.ValidatePassword(obj.Password, obj.ConfirmPassword);

                    while (flag == false) //if the given
                    {
                        Console.Write("\nPassword and Confirm Password should match !" +
                            "\nEnter Again: ");
                        Console.Write("\n\nEnter Password: ");
                        obj.Password = Console.ReadLine();

                        Console.Write("\nConfirm Password: ");
                        obj.ConfirmPassword = Console.ReadLine();

                        flag = val.ValidatePassword(obj.Password, obj.ConfirmPassword); //returns true if passwords match
                    }

                    string decision = businessOperation.ForgotPassword(obj);

                    if (decision == "success")
                    {
                        Console.WriteLine("\nPassword Updated successfully, redirecting to Login page.\n");
                        redirect = 1;
                    }
                    else if (decision == "fail")
                    {
                        Console.WriteLine("\nFailed to update password, Enter details correctly");
                        redirect = 3;
                    }
                }
            }
        }
    }
}
