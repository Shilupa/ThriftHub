﻿using System.Security.Claims;
using DataAccess.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThriftHub.Pages.ProductDetails
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Product objProduct { get; set; }
        public string routingPage { get; set; }

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objProduct = new Product();
        }

        public IActionResult OnGet(int productId)
        {
            if (productId != 0)
            {
                objProduct = _unitOfWork.Product.Get(p => p.Id == productId, includes: "Category,ApplicationUser");
            }

            if (objProduct == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            string? pageName = objProduct.Category?.Name;
            int? categoryId = objProduct.Category?.CategoryId;
            _unitOfWork.Product.Delete(objProduct);
            _unitOfWork.Commit();

            return RedirectToPage("../Index", new { categoryId = 1 });
        }
    }
}
