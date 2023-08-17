using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;

namespace ThriftHub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            // Page initialization logic, if needed
        }

        public JsonResult OnGetGetFilteredResults(string searchTerm, string selectedSort)
        {
            IQueryable<Product> query = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ApplicationUser);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p =>
                    p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            // Apply sorting based on selectedSort
            if (selectedSort == "date")
            {
                query = query.OrderBy(p => p.PublishedDate);
            }
            else if (selectedSort == "price")
            {
                query = query.OrderBy(p => p.Price);
            }

            var filteredResults = query.ToList();

            return new JsonResult(filteredResults);
        }
    }
}
