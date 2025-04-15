using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
	public class JobController : Controller
	{
		JobManager jobManager = new JobManager(new EfJobDal());
		public IActionResult Index()//listeleme işlemi
		{
			var values = jobManager.TGetList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddJob()//ürün ekleme işlemi
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddJob(Job j)//site uzerınden ürün ekleme işlemi
		{
			JobValidator validationRules = new JobValidator();
			ValidationResult result = validationRules.Validate(j);//p parametresini ProductValidator sınıfındaki Validate metoduna gönderiyoruz.
			if (result.IsValid)//kosul koyduk 
			{
				jobManager.TInsert(j);//productManager sınıfından TInsert metodunu çağırıyoruz ve p parametresini gönderiyoruz.
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
		public IActionResult DeleteJob(int id)//ürün silme işlemi
		{
			var value = jobManager.TGetById(id);//productManager sınıfından TGetById metodunu çağırıyoruz ve id parametresini gönderiyoruz.
			jobManager.TDelete(value);//productManager sınıfından TDelete metodunu çağırıyoruz ve productValue parametresini gönderiyoruz.
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateJob(int id)//ürün güncelleme işlemi
		{
			var value = jobManager.TGetById(id);//productManager sınıfından TGetById metodunu çağırıyoruz ve id parametresini gönderiyoruz.
			return View(value);//value değişkenini View'a gönderiyoruz.
		}
		[HttpPost]
		public IActionResult UpdateJob(Job j)
		{
			//var value = productManager.TGetById(p.Id);//productManager sınıfından TGetById metodunu çağırıyoruz ve p.Id parametresini gönderiyoruz.
			jobManager.TUpdate(j);//productManager sınıfından TUpdate metodunu çağırıyoruz ve p parametresini gönderiyoruz.
			return RedirectToAction("Index");
		}
	}
}
