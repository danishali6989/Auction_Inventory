﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuctionInventoryDAL.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AuctionInventoryEntities : DbContext
    {
        public AuctionInventoryEntities()
            : base("name=AuctionInventoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AllVehicleExpense> AllVehicleExpenses { get; set; }
        public virtual DbSet<CityMaster> CityMasters { get; set; }
        public virtual DbSet<CountryMaster> CountryMasters { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<MCategory> MCategories { get; set; }
        public virtual DbSet<MColor> MColors { get; set; }
        public virtual DbSet<MCompany> MCompanies { get; set; }
        public virtual DbSet<MCurrency> MCurrencies { get; set; }
        public virtual DbSet<MCustomer> MCustomers { get; set; }
        public virtual DbSet<MExpense> MExpenses { get; set; }
        public virtual DbSet<MStaff> MStaffs { get; set; }
        public virtual DbSet<MSupplier> MSuppliers { get; set; }
        public virtual DbSet<SingleVehicleExpense> SingleVehicleExpenses { get; set; }
        public virtual DbSet<StateMaster> StateMasters { get; set; }
        public virtual DbSet<TPurchase> TPurchases { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<ExpenseAmount> ExpenseAmounts { get; set; }
        public virtual DbSet<MailModel> MailModels { get; set; }
    }
}
