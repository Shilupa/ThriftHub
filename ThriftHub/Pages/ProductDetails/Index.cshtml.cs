using System.Security.Claims;
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

        [BindProperty]
        public ApplicationUser objUser { get; set; }

        public string? applicationUserId { get; private set; }

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objProduct = new Product();
            objUser = new ApplicationUser();
        }

        public IActionResult OnGet(int productId)
        {
            //check to see if user logged on
            //var claimsIdentity = User.Identity as ClaimsIdentity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //TempData["UserLoggedIn"] = claim;
            objProduct = _unitOfWork.Product.Get(p => p.Id == productId, includes: "Category");
            objUser = _unitOfWork.ApplicationUser.Get(u => u.Id == objProduct.ApplicationUserId);
            applicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Page();
        }

        public IActionResult OnPost()
        {

            _unitOfWork.Product.Delete(objProduct);

            _unitOfWork.Commit();

            return RedirectToPage("../Fashion/Index");
        }
    }
}
