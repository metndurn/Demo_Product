using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
	public class SettingsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _singInManager;

		public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager)
		{
			_userManager = userManager;
			_singInManager = singInManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);//sisteme giriş yapmış kullanıcıyı bul
			UserEditViewModel userEditViewModel = new UserEditViewModel();//model nesnesi oluştur
			userEditViewModel.Name = values.Name;
			userEditViewModel.SurName = values.Surname;
			userEditViewModel.Gender = values.Gender;
			userEditViewModel.EMail = values.Email;
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);//sisteme giriş yapmış kullanıcıyı bul
			user.Name = userEditViewModel.Name;
			user.Surname = userEditViewModel.SurName;
			user.Gender = userEditViewModel.Gender;
			user.Email = userEditViewModel.EMail;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);//şifreyi hashle önce parametre degeri daha sonrada yeni şifreyi kullanıcıdan aldırıp verıyoruz
			var result = await _userManager.UpdateAsync(user);//kullanıcıyı güncelle
			if (result.Succeeded)
			{
				await _singInManager.SignOutAsync();//kullanıcıyı tekrar giriş yaptır
				return RedirectToAction("Index", "Login");
			}
			else
			{
			}
			return View(result);
		}
	}
}
