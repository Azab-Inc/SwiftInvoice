using Microsoft.EntityFrameworkCore;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    internal class DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbContext() { }


    }
}
