using System.Diagnostics;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class BankAccountService
    {
        private DbService dbService = new DbService();

        public BankAccountService() 
        { 
            
        }

        public List<BankAccount> dbGetAccounts()
        {

            dbService.RunQuery();
            
            try
            {
                using (var connection = dbService.GetConnection())
                {
                    return connection.Table<BankAccount>().ToList();
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public BankAccount dbGetAccount(int accountId)
        {
            dbService.RunQuery();

            

            try
            {
                using (var connection = dbService.GetConnection())
                {
                    return connection.Table<BankAccount>().Where(a => a.AccountId == accountId).FirstOrDefault();
                    
                }
            }

            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }
        }

        public void dbAddAcount(BankAccount account, User user)
        {
            dbService.RunQuery();

            try
            {
                using (var connection = dbService.GetConnection())
                {
                    account.UserId = user.UserId;
                    connection.Insert(account);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void dbEditAccount(BankAccount account) 
        { 
            dbService.RunQuery();
            try {
                using (var connection = dbService.GetConnection())
                {
                    var existingAccount = connection.Table<BankAccount>().FirstOrDefault(i => i.AccountId == account.AccountId);
                    if (existingAccount != null)
                    {
                        existingAccount = account;
                        connection.Update(existingAccount);
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex); 
            }
        }

        public void dbRemoveAccount(BankAccount account)
        {
            dbService.RunQuery();
            try
            {
                using (var connection = dbService.GetConnection()) 
                {
                    connection.Table<BankAccount>().Delete(i => i.AccountId == account.AccountId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
