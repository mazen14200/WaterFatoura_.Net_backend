using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.models;

namespace RepositoryLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions con):base (con)
        {      
        }
        public DbSet<Default_Slice_Values> Tbl_Default_Slice_Values { get; set; }
        public DbSet<Invoices> Tbl_Invoices { get; set; }
        public DbSet<Real_Estate_Types> Tbl_Real_Estate_Types { get; set; }
        public DbSet<Subscriber_File> Tbl_Subscriber_File { get; set; }
        public DbSet<Subscription_File> Tbl_Subscription_File { get; set; }

        // we override the OnModelCreating method here.
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<Invoices>().HasKey(vf => new { vf.sp_id, vf.sp_Date });
            
            //modelBuilder.Entity<Subscription_File>().HasKey(vf => new { vf.sp_id, vf.sp_Date });


            //modelBuilder.Entity<Invoices>().HasOne(e => e.Real_Estate_Types_id)
            //.WithOne()
            //.HasForeignKey<Real_Estate_Types>(e => e.Code);

            //modelBuilder.Entity<Invoices>().HasOne(e => e.Subscription_No_sp_id)
            //.WithOne()
            //.HasForeignKey<Subscription_File>(e => e.sp_id);

            //modelBuilder.Entity<Invoices>().HasOne(e => e.Subscription_No_sp_Date)
            //.WithOne()
            //.HasForeignKey<Subscription_File>(e => e.sp_Date);

            //modelBuilder.Entity<Invoices>().HasOne(e => e.Subscriber_No)
            //.WithOne()
            //.HasForeignKey<Subscriber_File>(e => e.Id);
            

            //modelBuilder.Entity<Subscription_File>().HasOne(e => e.Subscriber_Code)
            //.WithOne()
            //.HasForeignKey<Subscriber_File>(e => e.Id);

            //modelBuilder.Entity<Subscription_File>().HasOne(e => e.Real_Estate_Types_id)
            //.WithOne()
            //.HasForeignKey<Real_Estate_Types>(e => e.Code);
        //}

    }

}
