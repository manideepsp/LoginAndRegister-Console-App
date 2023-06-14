using BLL;
using BusinessObjects;
using System;

namespace LoginAndRegister
{
	/// <summary>
	/// Frontend Class
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Main method
		/// </summary>
		public static void Main()
		{
			//Initialising new objects of Business objects and Business Logic classes
			BusinessObj obj = new BusinessObj();
			BusinessLogic operation = new BusinessLogic();

			int redirect;

            Console.WriteLine("Welcome to Landing page"
                + "\nEnter: "
                + "\n* 1. To Login"
                + "\n* 2. To Register As new user"
                + "\n* 3. If you forgot you password"
                + "\n* 0. To exit");
            redirect = Convert.ToInt32(Console.ReadLine());

			//loop runs until user exits application
			while (true)
			{
				if (redirect == 0) //To exit application
				{
					Console.WriteLine("***** Closing app *****");
					break;
				}
				else if (redirect == 1) //Login page
				{
					Console.Write("\nWelcome to Login Page:" +
						"\n\nEnter Username: ");
					obj.Username = Console.ReadLine();

					Console.Write("\nEnter Password: ");
					obj.Password = Console.ReadLine();

					string decision = operation.Login(obj);
					if(decision == "success")
					{
						redirect = 1;
					}
					else
					{
						redirect = 2;
					}
				}
				else if (redirect == 2)
				{
					Console.Write("Welcome to New User, enter your details to create new account:" +
						"\n\nEnter Username: ");
					obj.Username = Console.ReadLine();

					Console.Write("\nEnter First name: ");
					obj.FirstName = Console.ReadLine();

					Console.Write("\nEnter Last name: ");
					obj.LastName = Console.ReadLine();

					Console.Write("\nEnter email id: ");
					obj.Email = Console.ReadLine();

					Console.Write("\nEnter Mobile number: ");
					obj.Mobile = Console.ReadLine();

					Console.Write("\nEnter Password: ");
					obj.Password = Console.ReadLine();

					Console.Write("\nConfirm Password: ");
					obj.ConfirmPassword = Console.ReadLine();

					string decision = operation.CreateUser(obj);
					if (decision == "success")
					{
						redirect = 1;
					}
					else
					{
						redirect = 0;
					}
				}
				else if (redirect == 3)
				{
					Console.Write("\nWelcome to forgot password page:"
						+ "\n\nEnter username: ");
					obj.Username = Console.ReadLine();

					Console.Write("\nEnter the new password: ");
					obj.Password = Console.ReadLine();

					Console.Write("\nConfirm Password: ");
					obj.ConfirmPassword = Console.ReadLine();

					string decision = operation.ForgotPassword(obj);

					if (decision == "success")
					{
						Console.WriteLine("\nUser created successfully, redirecting to Login page.\n");
						redirect = 1; 
					}
					else if (decision == "fail")
					{
						Console.WriteLine("\nUser doesnot exist, create new user: ");
						redirect = 2;
					}
				}

			}

		}
	}
}