using BookCartApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Data
{
    public class BookContext : IdentityDbContext<User, Role, int>
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }
        public override DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserSubscriptionRelation> UserSubscriptionRelations { get; set; }
        public DbSet<IdentityUserRole<int>> UserRoleRelations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserSubscriptionRelation>(b => { b.HasKey(k => new { k.BookId, k.SubscriptionId, k.UserId }); });
            builder.Entity<IdentityUserRole<int>>(b => { b.ToTable("UserRoleRelation"); b.HasKey(k => new { k.UserId, k.RoleId }); });
            builder.Entity<IdentityRoleClaim<int>>(b => { b.ToTable("_Not_Used_RoleClaim"); });
            builder.Entity<IdentityUserClaim<int>>(b => { b.ToTable("_Not_Used_Claim"); });
            builder.Entity<IdentityUserLogin<int>>(b => { b.ToTable("_Not_Used_Login"); b.HasKey(k => new { k.LoginProvider, k.ProviderKey }); });
            builder.Entity<IdentityUserToken<int>>(b => { b.ToTable("_Not_Used_Token"); b.HasKey(k => new { k.UserId, k.LoginProvider, k.Name }); });
        }

    }
}
