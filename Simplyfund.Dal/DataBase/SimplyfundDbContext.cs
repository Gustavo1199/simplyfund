using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Models.Auth;
using SimplyFund.Domain.Models.Client;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Customer;
using SimplyFund.Domain.Models.Email.NotificationsModel;
using SimplyFund.Domain.Models.Funds;
using SimplyFund.Domain.Models.Requests;
using SimplyFund.Domain.Models.Requests.Offers;
using SimplyFund.Domain.Models.Requests.Offers.AddedOffers;
using SimplyFund.Domain.Models.Smtp;
using SimplyFund.Domain.Models.Warrantys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = SimplyFund.Domain.Models.Common.File;

namespace Simplyfund.Dal.DataBase
{
    public class SimplyfundDbContext : IdentityDbContext<User>
    {
        public SimplyfundDbContext(DbContextOptions<SimplyfundDbContext> options) : base(options)
        {
             
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Commission> Commisions { get; set; }
        public DbSet<Bank> Banks { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<IdentityType> IdentityTypes { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }

        public DbSet<Shareholder> Shareholders { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<FinancialSummary> FinancialSummary { get; set; }
  
        public DbSet<SeniorityBalance> SeniorityBalances { get; set; }
        public DbSet<LaborData> LaborDatas { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<CustomerFinancialSummary> CustomerFinancialSummaries { get; set; }
        public DbSet<FinancialSummary> LegalFinancialSumaries { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<File> Files { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationModule> NotificationModules { get; set; }
        public DbSet<NotificationAction> NotificationActions { get; set; }
        public DbSet<NotificationTarget> NotificationTargets { get; set; }
        public DbSet<NotificationExecutionType> NotificationExecutionTypes { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<Request> REQUESTS { get; set; }
        public DbSet<RequestCategory> RequestCategories { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Warranty> Warranties { get; set; }


        public DbSet<OfferRequest> OffersRequests { get; set; }
        public DbSet<OfferRequestPeriod> OffersRequestsPeriods { get; set; }
        public DbSet<OfferType> OffersTypes { get; set; }
        public DbSet<OfferStatus> OffersStatus { get; set; }
        public DbSet<AddedOffer> AddedOffers { get; set; }

        public DbSet<WarrantyField> WarrantyFields { get; set; }

        public DbSet<Modality> Modalitys { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<OffersRequestsComment> OffersRequestsComments { get; set; }
        public DbSet<RequestExpenseRelation> RequestExpenseRelation { get; set; }
        public DbSet<AmortizationTable> AmortizationTables { get; set; }
        public DbSet<CustomerWorkingInfo> CustomerWorkingInfo { get; set; }
        public DbSet<FundIncreaseRequest> IncreasedFundsRequests { get; set; }
        public DbSet<FundIncreaseRequestStatus> FundIncreaseRequestStatus { get; set; }
        public DbSet<FundIncreaseRequestComments> FundIncreaseRequestComments { get; set; }



        //public DbSet<NotificationGroup> NotificationGroups { get; set; }
        //public DbSet<NotificationGroupsNotification> NotificationGroupsNotifications { get; set; }




        public DbSet<Smtp> SMTP { get; set; }





      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
       
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");       
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
              

            });

            //    modelBuilder.Entity<Country>()
            //.Ignore(e => e.Request.Method);

  


            //modelBuilder.Entity<User>()
            //                    .Property(b => b.CreatedDate)
            //                    .HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<User>()
            //                    .Property(b => b.LastUpdate)
            //                    .HasDefaultValue(DateTime.Now);

            //modelBuilder.Entity<Expense>()
            //        .HasIndex(e => new { e.ExpenseName, e.BadgeId })
            //        .IsUnique(true);

            //modelBuilder.Entity<BankAccount>()
            //       .HasIndex(b => new { b.AccountNumber, b.BankId })
            //       .IsUnique(true);
            //modelBuilder.Entity<FinancialSummary>()
            //     .HasIndex(f => new { f.CustomerId, f.YearOfSummary })
            //     .IsUnique(true);
        }
    }
}
