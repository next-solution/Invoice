using Invoice.Core.Domain;
using Invoice.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Infrastructure.EF
{
    public class InvoiceContext : DbContext
    {
        private readonly SqlSettings _settings;
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceDocument> InvoiceDocuments { get; set; }

        public InvoiceContext(DbContextOptions<InvoiceContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();

                return;
            }
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(x => x.Id);
            var customerBuilder = modelBuilder.Entity<Customer>();
            customerBuilder.HasKey(x => x.Id);
            var invoiceDocumentBuilder = modelBuilder.Entity<InvoiceDocument>();
            invoiceDocumentBuilder.HasKey(x => x.Id);
        }
    }
}
