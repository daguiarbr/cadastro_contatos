using System;
using Contacts.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Contacts.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConStr") { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
