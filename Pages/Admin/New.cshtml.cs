using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketCatalog.Data;
using SupermarketCatalog.Models;

namespace SupermarketCatalog.Pages.Admin;

[Authorize]
public class NewModel(AppDbContext db, UserManager<StoreUser> userManager) : PageModel
{
    [BindProperty]
    public Deal Deal { get; set; } = new() { ExpiresAt = DateTime.UtcNow.AddDays(7) };

    [BindProperty]
    public IFormFile? ImageFile { get; set; }

    public string Lang => Request.Query["lang"].FirstOrDefault() ?? "ku";
    public string Dir => Lang == "en" ? "ltr" : "rtl";

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await userManager.GetUserAsync(User);
        if (user is null) return Unauthorized();

        if (user.ActiveDealsCount >= user.MonthlyDealLimit)
            return BadRequest("Deal limit reached");

        // Handle image upload
        if (ImageFile is not null)
        {
            var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            Directory.CreateDirectory(uploadsDir);
            var fileName = $"{Guid.NewGuid()}_{ImageFile.FileName}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var stream = System.IO.File.Create(filePath))
                await ImageFile.CopyToAsync(stream);

            Deal.ImageUrl = $"/uploads/{fileName}";
        }

        Deal.StoreId = 1; // Default store
        db.Deals.Add(Deal);
        user.ActiveDealsCount++;
        await db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}