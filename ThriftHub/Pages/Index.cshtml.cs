using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Infrastructure;

namespace ThriftHub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<Product> objProductList;

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objProductList = new List<Product>();
        }

        public IActionResult OnGet(string searchTxt)
        {

            if (String.IsNullOrEmpty(searchTxt))
            {
                objProductList = _unitOfWork.Product.GetAll();

            }
            else
            {
                // Search item by product name or description
                objProductList = _unitOfWork.Product.GetAll()
     .Where(s =>
         s.Name?.IndexOf(searchTxt, StringComparison.OrdinalIgnoreCase) >= 0 ||
         s.Description?.IndexOf(searchTxt, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            return Page();
        }
    }
}
