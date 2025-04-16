using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_Product.Controllers
{
	public class CustomerController : Controller
	{
		CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
		JobManager jobManager = new JobManager(new EfJobDal());
		public IActionResult Index()//customer listeleme 
		{
			var values = customerManager.GetCustomersListWithJob();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddCustomer()//customer ekleme
		{
			/*customer alanına aıt tek seferlık kod yazılıp buradaki verileri liste halinde
			 dropdownlist olarak secılebılır sekle soktuk kodu daha sonra kaldırıp en yukarıya verdık unutma*/
			
			List<SelectListItem> values = (from x in jobManager.TGetList()//customerManager sınıfından TGetList metodunu çağırıyoruz ve listeleme yapıyoruz.
				select new SelectListItem()
				{
				Text = x.Name,
				Value = x.JobId.ToString(),
				}).ToList();
			ViewBag.c = values;//ViewBag ile listeyi view'e gönderiyoruz.
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
			List<SelectListItem> values = (from x in jobManager.TGetList()//customerManager sınıfından TGetList metodunu çağırıyoruz ve listeleme yapıyoruz.
										   select new SelectListItem()
										   {
											   Text = x.Name,
											   Value = x.JobId.ToString(),
										   }).ToList();
			ViewBag.c = values;//ViewBag ile listeyi view'e gönderiyoruz.
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
