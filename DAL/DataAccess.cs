using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DataAccess
    {
        List<List<string>> objectsData = new List<List<string>>();
        List<String> listData = new List<String>();
        public void CreateNewUser(BusinessObj obj)
        { 
            listData.Clear();
            listData.Add(obj.Username);
            listData.Add(obj.Password);
            listData.Add(obj.FirstName);
            listData.Add(obj.LastName);
            listData.Add(obj.Email);
            listData.Add(obj.Mobile);
            objectsData.Add(listData);
            Console.WriteLine("Account created successfully");
        }
        public bool CheckIfPresent(string username)
        {
            for(int i=0; i<objectsData.Count; i++)
            {
                if (objectsData[i].Contains(username))
                    return true;
            }
            return false;
        }
        public bool CheckIfPresent(string username, string password)
        {
            for(int i=0; i<objectsData.Count; i++)
            {
                if (objectsData[i].Contains(username) && objectsData[i].Contains(password))
                    return true;
            }
            return false;
        }
        public void UpdatePassword(string password, string username)
        {
            for(int i=0; i<objectsData.Count;i++)
            {
                if (objectsData[i][0] == username)
                {
                    objectsData[i][1] = password;
                }
            }
        }
    }
}
