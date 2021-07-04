
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using BookCartApi.Models;

namespace BookCartApi.Data
{

    public static class MyIdentityDataInitializer
    {
        public static void SeedAdminUser(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (userManager.FindByNameAsync("yngwenduma").Result == null)
            {
                User user = new User
                {
                    Email = "yongz.ngwenduna@gmail.com",
                    PasswordHash = "",
                    UserName = "yngwenduma",
                    FirstName = "Yongama",
                    LastName = "Ngwenduma",
                    EmailConfirmed = true,
                };
                // await  
                
                var result = userManager.CreateAsync(user, "N0tSys@dm!n").Result;
                
            }
            //if (roleManager.RoleExistsAsync("Admin").Result == false)
            //{
            //    var admin = new Role { Name = "Admin", Code = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() };
            //    var Moderator = new Role { Name = "Moderator", Code = "Moderator", ConcurrencyStamp = Guid.NewGuid().ToString() };
            //    roleManager.CreateAsync(admin);
            //    roleManager.CreateAsync(Moderator);
            //}

        }
    }
    public static class BookContextInitializer
    {
        public static void Initialize(BookContext context)
        {
            if (!context.Books.Any())
            {
                var books = new List<Book>()
                {
                    new Book{ PurchasePrice=980, Category="Classics",  ISBNo="1", Name="To Kill a Mockingbird", },
                    new Book{ PurchasePrice=202, Category="Classics",  ISBNo="2", Name="Little Women",          },
                    new Book{ PurchasePrice=239, Category="Classics",  ISBNo="3", Name="Beloved",               },

                    new Book{PurchasePrice=2000, Category="Horror", ISBNo="1",Name="The Haunting of Hill House", },
                    new Book{PurchasePrice=500, Category="Horror", ISBNo="1",Name="Bird Box",                   },
                    new Book{PurchasePrice=650, Category="Horror", ISBNo="1",Name="Carrie",                     },

                    new Book{PurchasePrice=178,Category="Novel",  ISBNo="4" ,Name="Watchmen",                                 },
                    new Book{PurchasePrice=150,Category="Novel",  ISBNo="6" ,Name="The Walking Dead: Compendium One",         },
                    new Book{PurchasePrice=300,Category="Novel",  ISBNo="2" ,Name="The Boy, the Mole, the Fox and the Horse", },

                    new Book{ PurchasePrice=300, Name="The Water Dancer", Category="fantasy",  ISBNo="3"},
                    new Book{ PurchasePrice=910, Name="Circe", Category="fantasy",  ISBNo="4",},
                    new Book{ PurchasePrice=450, Name="Ninth House", Category="fantasy",  ISBNo="6"},
                };
                books.ForEach(acr => context.Books.Add(acr));
                context.SaveChanges();
            }
            if (!context.Subscriptions.Any())
            {
                var subscriptions = new List<Subscription>()
                {
                    new Subscription{DiscountPercentage=0, Months = 1,  Description="Monthly Subscription", },
                    new Subscription{DiscountPercentage=20, Months = 12,  Description="Annual Subscription", },
                };
                subscriptions.ForEach(acr => context.Subscriptions.Add(acr));
                context.SaveChanges();
            }
           
        }
    }
}
