/*
================================================================================
ASP.NET Core MVC ENTRY POINT
================================================================================
*/

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

/*---+---+---+--Start of Services Configuration Block---+---+---+--*/
// Note to self--Add MVC services to the container
builder.Services.AddControllersWithViews();
/*---+---+---+--End of Services Configuration Block---+---+---+--*/


var app = builder.Build();

/*---+---+---+--Start of Middleware Pipeline Block---+---+---+--*/
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Note to self--Map default route: "{controller=Home}/{action=Index}/{id?}"
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
/*---+---+---+--End of Middleware Pipeline Block---+---+---+--*/


app.Run();