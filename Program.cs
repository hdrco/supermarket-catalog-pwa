using Microsoft.EntityFrameworkCore;
using SupermarketCatalog.Data;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(o=>o.UseSqlite(builder.Configuration.GetConnectionString("Default")??"Data Source=app.db"));
builder.Services.AddDistributedMemoryCache(); builder.Services.AddSession();
var app=builder.Build();
using(var scope=app.Services.CreateScope()){var db=scope.ServiceProvider.GetRequiredService<AppDbContext>(); db.Database.EnsureCreated(); Seed.Data(db);}
if(!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error");
app.UseHttpsRedirection(); app.UseSecurityHeaders(); app.UseStaticFiles(); app.UseRouting(); app.UseSession(); app.MapRazorPages(); app.Run();