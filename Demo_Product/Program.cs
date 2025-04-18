using DataAccessLayer.Concrete;
using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*veritabanýna kayýtlarýn gelmesi gerekiyor o yuzden bunlar yazýldý
 * hem user hemde role ýslemlerý olmus olacak*/
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>
    ().AddEntityFrameworkStores<Context>
    ().AddErrorDescriber<CustomIdentityValidator>();//daha sonra bu eklendý hata kodlarýný versýn dýye
builder.Services.AddControllersWithViews();//controller ve view eklenmesi için gerekli olan kodlar
/*bu kýsýmda authorize iþlemi yapýldý yani kullanýcý giriþ yapmadan bu sayfaya eriþemez */
builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
        config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
