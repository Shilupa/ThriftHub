using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace DataAccess
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            _db.Database.EnsureCreated();

            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }
            //check to see if one table has data.  If so, do not insert any data
            if (_db.Categories.Any())
            {
                return; //DB has been seeded
            }

            //create roles if they are not created
            //SD is a “Static Details” class we will create in Utility to hold constant strings for Roles
            _roleManager.CreateAsync(new IdentityRole(SD.AdminRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).GetAwaiter().GetResult();

            //Creating “Admin”.
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "nischhal@hotmail.com",
                Email = "nischhal@hotmail.com",
                FirstName = "Nischhal",
                LastName = "Shrestha",
                PhoneNumber = "0444848484",
                StreetAddress = "Maininkite 10",
                CardNumber = "1111-2221-2224-2424",
                PostalCode = "48484",
                City = "Espoo"
            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser user1 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "nischhal@hotmail.com");

            _userManager.AddToRoleAsync(user1, SD.AdminRole).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "shilpa@hotmail.com",
                Email = "shilpa@hotmail.com",
                FirstName = "Shilpa",
                LastName = "Singh",
                PhoneNumber = "8015556919",
                StreetAddress = "Kivenlahti 7",
                CardNumber = "333-6661-2224-5454",
                PostalCode = "84408",
                City = "Espoo"
            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser user2 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "shilpa@hotmail.com");

            _userManager.AddToRoleAsync(user2, SD.AdminRole).GetAwaiter().GetResult();
            //Now continue with your tables

            var Categories = new List<Category>
            {

            new Category { Name = "FASHION" },
            new Category { Name = "ELECTRONICS"},
            new Category { Name = "FURNITURE" },
            new Category { Name = "SPORTS" },
            new Category { Name = "HEALTH & BEAUTY"},
            new Category { Name = "MISCELLANEOUS" }
            };

            foreach (var c in Categories)
            {
                _db.Categories.Add(c);
            }
            _db.SaveChanges();
        }
    }
}