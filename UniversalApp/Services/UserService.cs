using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class UserService
    {
        public User currentUser = new User();


    
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SwiftInvoiceData", "User", "user.json");
        

        public User getUser()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    currentUser = JsonSerializer.Deserialize<User>(jsonData);
                }
                else
                {
                    // File exists but is empty, initialize with default values
                    currentUser = new User();
                }
            }
            else
            {
                // File does not exist, initialize with default values
                currentUser = new User();
            }
            return currentUser;
        }
    }
}
