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
        public List<Product> filteredProducts { get; set; }

        public CommonIndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objProductList = new List<Product>();
            filteredProducts = new List<Product>();
        }

        public IActionResult OnGet(int categoryId)
        {
            Console.Write("feafef", categoryId);
            //ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ApplicationUsername = User.FindFirstValue(ClaimTypes.Name);
            //FirstName = User.FindFirstValue(ClaimTypes.GivenName);
            objProductList = _unitOfWork.Product.GetAll(o => o.Category.CategoryId == categoryId, null, "Category");

            // Assuming objProductList is a collection of products
            //filteredProducts = objProductList.Where(product => product.CategoryId == SD.ElectronicsId).ToList();
            return Page();
        }
    }
}
