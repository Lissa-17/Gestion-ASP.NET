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
    public class Login : PageModel
    {        
        [BindProperty]
        public LoginModel Input { get; set; }
        private readonly SignInManager<AppUser> signIn;

        public Login(SignInManager<AppUser> signIn)
        {    
            this.signIn = signIn;            
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var res = await signIn.PasswordSignInAsync(Input.Email, Input.Password, false, false);
                if (res.Succeeded)
                {
                    return RedirectToPage("../Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
        public async Task<IActionResult> OnGetLogOut()
        {
            await signIn.SignOutAsync();
            return RedirectToPage("/Admin/Login");
        } 
    }
}