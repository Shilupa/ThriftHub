using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThriftHub.Pages
{
    public class CommonIndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<Product> objProductList;

        public CommonIndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objProductList = new List<Product>();
        }

        public IActionResult OnGet(int categoryId)
        {
            objProductList = _unitOfWork.Product.GetAll(p => p.Category.CategoryId == categoryId, null, "Category,ApplicationUser");
            return Page();
        }
    }
}
