﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThriftHub.Pages.Profile
{
	public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public ApplicationUser objUser { get; set; }
        public string? applicationUserId { get; set; }

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objUser = new ApplicationUser();
        }

        public IActionResult OnGet()
        {
            //ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ApplicationUsername = User.FindFirstValue(ClaimTypes.Name);
            //FirstName = User.FindFirstValue(ClaimTypes.GivenName);
            applicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.Write("myGetsfefef");
            objUser = _unitOfWork.ApplicationUser.Get(u => u.Id == applicationUserId);

            return Page();
        }
    }
}