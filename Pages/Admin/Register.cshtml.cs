#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionHopital.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GestionHopital.Pages.Admin
{
    public class Register : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        [BindProperty]
        public InputModel Input { get; set; }

        public Register(UserManager<AppUser> user)
        {
            _userManager = user;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {                   
            AppUser appuser = new AppUser{UserName = Input.Email, Email=Input.Email};

            var res = await _userManager.CreateAsync(appuser, Input.Password);
            if(res.Succeeded)
            {
                return RedirectToPage("/Admin/login");
            }                                 
            return Page();            
        }
    }
}