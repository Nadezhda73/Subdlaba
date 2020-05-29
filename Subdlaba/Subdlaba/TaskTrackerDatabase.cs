using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Subdlaba.Models;

namespace Subdlaba
{
    public class TaskTrackerDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1P2ORBM;Initial Catalog=TaskTrackerDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(c => c.Username);
            modelBuilder.Entity<Project>().HasIndex(c => c.Name);
            modelBuilder.Entity<Tracker>().HasIndex(c => c.Ticket);
        }
        public virtual DbSet<Customer> Customers { set; get; }
        public virtual DbSet<Developer> Developers { set; get; }
        public virtual DbSet<DeveloperTracker> DeveloperTrackers { set; get; }
        public virtual DbSet<Project> Projects { set; get; }
        public virtual DbSet<Timing> Timings { get; set; }
        public virtual DbSet<Tracker> Trackers { get; set; }
    }
}
