using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    /// <summary>
    /// Data Access Layer
    /// </summary>
    public class DataAccess
    {
        //Using List of strings to store in-memory
        public static List<List<string>> userData = new List<List<string>>();
        public static List<String> listData = new List<String>();

        /// <summary>
        /// Creates new User
        /// </summary>
        /// <param name="obj"></param>
        public void CreateNewUser(BusinessObj obj)
        { 
            listData.Clear();
            listData.Add(obj.Username);
            listData.Add(obj.Password);
            listData.Add(obj.FirstName);
            listData.Add(obj.LastName);
            listData.Add(obj.Email);
            listData.Add(obj.Mobile);
            userData.Add(listData);
        }

        /// <summary>
        /// checks if username is present in the User Data
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckIfPresent(string username)
        {
            for(int i=0; i<userData.Count; i++)
            {
                if (userData[i].Contains(username))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// overloads CheckIfPresent method and checks if username and password present in the User Data
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckIfPresent(string username, string password)
        {
            for(int i=0; i<userData.Count; i++)
            {
                if (userData[i].Contains(username) && userData[i].Contains(password))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the existing password in User Data w.r.t Username given
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UpdatePassword(string password, string username)
        {
            for(int i=0; i<userData.Count;i++)
            {
                if (userData[i][0] == username)
                {
                    userData[i][1] = password;
                    return true;
                }
            }
            return false;
        }
    }
}
