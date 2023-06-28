using System.Text.Json;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class UserService
    {
        public User currentUser = new User();
          
        public User getUser()
        {
            if (File.Exists(getUserFile()))
            {
                string jsonData = File.ReadAllText(getUserFile());
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

        public async Task saveUser(User user)
        {
            string jsonData = JsonSerializer.Serialize(user);
            Directory.CreateDirectory(Path.GetDirectoryName(getUserFile()));
            await File.WriteAllTextAsync(getUserFile(), jsonData);
        }

        public string getUserFile()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SwiftInvoiceData", "User", "user.json");
        }
    }
}
