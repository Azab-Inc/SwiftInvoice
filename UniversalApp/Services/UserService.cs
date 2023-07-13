using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class UserService
    {
        private DbService dbService = new DbService();

        public UserService()
        {

        }

        public void dbSaveUser(User user)
        {
            dbService.RunQuery();
            try
            {
                dbService.GetConnection().Update(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        public User dbLoadUser()
        {
            dbService.RunQuery();
            try
            {
                User user = dbService.GetConnection().Table<User>().FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
    }
}
