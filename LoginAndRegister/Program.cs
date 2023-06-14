using BLL;
using BusinessObjects;
using DAL;
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
			BusinessLogic businessOperation = new BusinessLogic();
			DataAccess dataOperation = new DataAccess();
			Menu call = new Menu();

			int redirect;

            Console.WriteLine("Welcome to Landing page"
                + "\n  Enter: "
                + "\n* 1. To Login"
                + "\n* 2. To Register As new user"
                + "\n* 3. If you forgot you password"
                + "\n* 0. To exit");
            redirect = Convert.ToInt32(Console.ReadLine());

			call.MenuOperation(redirect, obj, businessOperation, dataOperation);
		}
	}
}