using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimPortfolioApp.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TimPortfolioApp.Repository
{
    public class PostgresDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>

    {
        // add db models
        public DbSet<SampleItem> SampleItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            // builder.Entity<ApplicationUser>(b =>
            // {
            //     // Primary key
            //     b.HasKey(u => u.Id);
            //
            //     // Indexes for "normalized" username and email, to allow efficient lookups
            //     b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            //     b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
            //
            //     // Maps to the AspNetUsers table
            //     b.ToTable("AspNetUsers");
            //
            //     // A concurrency token for use with the optimistic concurrency checking
            //     b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
            //
            //     // Limit the size of columns to use efficient database types
            //     b.Property(u => u.UserName).HasMaxLength(256);
            //     b.Property(u => u.NormalizedUserName).HasMaxLength(256);
            //     b.Property(u => u.Email).HasMaxLength(256);
            //     b.Property(u => u.NormalizedEmail).HasMaxLength(256);
            //
            //     // The relationships between User and other entity types
            //     // Note that these relationships are configured with no navigation properties
            //
            //     // // Each User can have many UserClaims
            //     // b.HasMany<IdentityUserClaim<int>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            //     //
            //     // // Each User can have many UserLogins
            //     // b.HasMany<IdentityUserLogin<int>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            //     //
            //     // // Each User can have many UserTokens
            //     // b.HasMany<IdentityUserToken<int>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            //     //
            //     // // Each User can have many entries in the UserRole join table
            //     // b.HasMany<IdentityUserRole<int>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            // });
        }
    }
}
