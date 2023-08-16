using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility;

namespace ThriftHub.Pages.Electronics
{
	public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<Product> objProductList;
        public List<Product> filteredProducts { get; set; }

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objProductList = new List<Product>();
            filteredProducts = new List<Product>();
        }

        public IActionResult OnGet()
        {
            //ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ApplicationUsername = User.FindFirstValue(ClaimTypes.Name);
            //FirstName = User.FindFirstValue(ClaimTypes.GivenName);
            objProductList = _unitOfWork.Product.GetAll();

            // Assuming objProductList is a collection of products
            filteredProducts = objProductList.Where(product => product.CategoryId == SD.ElectronicsId).ToList();
            return Page();
        }
    }
}
