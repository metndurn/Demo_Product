using DataAccessLayer.Concrete;
using Demo_Product.Models;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*veritaban�na kay�tlar�n gelmesi gerekiyor o yuzden bunlar yaz�ld�
 * hem user hemde role �slemler� olmus olacak*/
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>
    ().AddEntityFrameworkStores<Context>
    ().AddErrorDescriber<CustomIdentityValidator>();//daha sonra bu eklend� hata kodlar�n� vers�n d�ye
builder.Services.AddControllersWithViews();//controller ve view eklenmesi i�in gerekli olan kodlar
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
