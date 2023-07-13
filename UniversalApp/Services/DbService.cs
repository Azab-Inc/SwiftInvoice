﻿using SQLite;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class DbService
    {
        private string dbPath;              

        public DbService()
        {         
            
            GetConnection().CreateTable<User>();
            GetConnection().CreateTable<Invoice>();
            GetConnection().CreateTable<Item>();
            RunQuery();
        }

        public SQLiteConnection GetConnection()
        {
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SwiftInvoice",  "SwiftInvoiceData.db3");
            return new SQLiteConnection(dbPath);
        }

        public void RunQuery()
        {
            bool hasUsers = GetConnection().Table<User>().Any();

            if (!hasUsers)
            {
                User user = new User();

                GetConnection().Insert(user);
            }
        }
    }
}
