using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages.Auth;

public class RegisterModel(UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager) : PageModel
{
    [BindProperty]
    public string StoreName { get; set; } = "";

    [BindProperty]
    public string Email { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    [BindProperty]
    public string ConfirmPassword { get; set; } = "";

    public string Lang => Request.Query["lang"].FirstOrDefault() ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task<IActionResult> OnPostAsync()
    {
        if (Password != ConfirmPassword)
        {
            ModelState.AddModelError("", "Passwords do not match");
            return Page();
        }

        var user = new StoreUser
        {
            UserName = Email,
            Email = Email,
            StoreName = StoreName,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, Password);
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent: true);
            return RedirectToPage("/Admin/Index");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return Page();
    }
}