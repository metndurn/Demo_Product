using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;//_usermanager resgister işlemleri icin kullanılacak

		public RegisterController(UserManager<AppUser> userManager)//constractır metoduna atama yapıldı 
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		/*await komutları kullanılacagı zaman metodun basındakı ıactıonresult async <task> ıcıne almamız gerekır unutma*/
		[HttpPost]
		public async Task<IActionResult> Index(UserRegisterViewModel model)//modelden bir parametre gondermesı ıcın UserRegisterViewModel verdık
		{
			if (string.IsNullOrEmpty(model.Password))
			{
				ModelState.AddModelError("Password", "Sifre alanı boş bırakılamaz.");
				return View(model);
			}
			//tanımlama yapıp atama yapıyoruz
			AppUser appUser = new AppUser()//kullanıcıdan degerleri alıp atıyoruz
			{
				Name = model.Name,
				Surname = model.SurName,
				UserName = model.UserName,
				Email = model.EMail
			};
			/*kosulda sifreler aynı mı dedık aynı ıse ekle ekleme yapıldıgı vakıt ıkıncı kosulda login yapsın dedık*/
			if (model.Password == model.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, model.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
				else/*eger hata olustuysa bana hatanın nerede oldugunu viewda goster dedık*/
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(model);
		}
	}
}
