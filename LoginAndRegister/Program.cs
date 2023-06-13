using BLL;
using BusinessObjects;
using System;

namespace LoginAndRegister
{
	public class Program
	{
		public static void Main()
		{
			BusinessObj obj = new BusinessObj();
			BusinessLogic operation = new BusinessLogic();

			int input;

			bool flag = true;
			while (flag)
			{
				Console.WriteLine("Welcome to Landing page"
				+"/nEnter: "
				+"/n*1. To Login"
				+ "/*2. To Register As new user"
				+ "/n*3. If you forgot you password"
				+ "*0. To exit");

				input = Convert.ToInt32(Console.ReadLine());
				if (input == 0)
				{
					Console.WriteLine("Closing app");
					flag = false;
				}
				else if (input == 1)
				{
					Console.WriteLine("Welcome to Login Page:" +
						"/n/nEnter Username: ");
					obj.Username = Console.ReadLine();

					Console.WriteLine("/nEnter Password: ");
					obj.Password = Console.ReadLine();
					string decision = operation.Login(obj);
					if(decision == "success" || decision == "fail")
					{
						input = 1;
					}
				}
				else if (input == 2)
				{
					Console.WriteLine("Welcome to New Uesr:" +
						"/n/nEnter Username: ");
					obj.Username = Console.ReadLine();

					Console.WriteLine("/nEnter First name: ");
					obj.FirstName = Console.ReadLine();

					Console.WriteLine("/nEnter Last name: ");
					obj.LastName = Console.ReadLine();

					Console.WriteLine("/nEnter email id: ");
					obj.Email = Console.ReadLine();

					Console.WriteLine("/nEnter Mobile number: ");
					obj.Mobile = Console.ReadLine();

					Console.WriteLine("/nEnter Password: ");
					obj.Password = Console.ReadLine();

					Console.WriteLine("/nConfirm Password: ");
					obj.ConfirmPassword = Console.ReadLine();

					string decision = operation.CreateUser(obj);
					if (decision == "success") input = 1;
					else input = 0;
				}
				else if (input == 3)
				{
					Console.WriteLine("Welcome to forgot password page:"
						+ "/n/nEnter username: ");
					obj.Username = Console.ReadLine();
					Console.WriteLine("/nEnter the new password: ");
					obj.Password = Console.ReadLine();
					Console.WriteLine("/nConfirm Password: ");
					obj.ConfirmPassword = Console.ReadLine();

					string decision = operation.ForgotPassword(obj);
					if (decision == "success") input = 1;
					else if (decision == "fail") input = 3;
				}

			}

		}
	}
}