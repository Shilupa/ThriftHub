using DataAccess.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThriftHub.Pages.Fashion
{
    public class IndexModel : PageModel
    {
        //public string? ApplicationUserId { get; private set; }
        //public string? ApplicationUsername { get; private set; }
        //public string? FirstName { get; private set; }
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<Product> objProductList;

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objProductList = new List<Product>();
        }

        public IActionResult OnGet()
        {
            //ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ApplicationUsername = User.FindFirstValue(ClaimTypes.Name);
            //FirstName = User.FindFirstValue(ClaimTypes.GivenName);
            objProductList = _unitOfWork.Product.GetAll();
            return Page();
        }
    }
}
