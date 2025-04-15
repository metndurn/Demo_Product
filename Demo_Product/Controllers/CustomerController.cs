using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
	public class CustomerController : Controller
	{
		CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
		public IActionResult Index()//customer listeleme 
		{
			var values = customerManager.TGetList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddCustomer()//customer ekleme
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCustomer(Customer c)//site uzerınden customer ekleme
		{
			CustomerValidator validationRules = new CustomerValidator();
			ValidationResult result = validationRules.Validate(c);//c parametresini CustomerValidator sınıfındaki Validate metoduna gönderiyoruz.
			if (result.IsValid)//kosul koyduk 
			{
				customerManager.TInsert(c);//customerManager sınıfından TInsert metodunu çağırıyoruz ve c parametresini gönderiyoruz.
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)//eger olmazsa hata
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//ModelState'e hata mesajlarını ekliyoruz.
				}
			}
			return View();
		}
		public IActionResult DeleteCustomer(int id)//customer silme
		{
			var value = customerManager.TGetById(id);
			customerManager.TDelete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateCustomer(int id)//customer güncelleme
		{
			var value = customerManager.TGetById(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateCustomer(Customer c)//customer güncelleme
		{
			customerManager.TUpdate(c);
			return RedirectToAction("Index");
		}
	}
}
