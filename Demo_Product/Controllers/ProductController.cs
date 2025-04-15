using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Metadata;

namespace Demo_Product.Controllers
{
	public class ProductController : Controller
	{
		//new keywordu ile ProductManager sınıfından bir nesne oluşturduk ve EfProductDal sınıfını parametre olarak verdik.Bu sayede ProductManager sınıfı içinde IProductDal arayüzünü implement eden EfProductDal sınıfını kullanabileceğiz.
		ProductManager productManager = new ProductManager(new EfProductDal());
		public IActionResult Index()//listeleme işlemi
		{
			//productManager sınıfından TGetList metodunu çağırıyoruz ve dönen değeri values değişkenine atıyoruz.
			//values değişkenini View'a gönderiyoruz.
			//View, values değişkenini kullanarak verileri görüntüleyecek.
			var values = productManager.TGetList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddProduct()//ürün ekleme işlemi
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddProduct(Product p)//site uzerınden ürün ekleme işlemi
		{
			ProductValidator validationRules = new ProductValidator();
			ValidationResult result = validationRules.Validate(p);//p parametresini ProductValidator sınıfındaki Validate metoduna gönderiyoruz.
			if (result.IsValid)//kosul koyduk 
			{
				productManager.TInsert(p);//productManager sınıfından TInsert metodunu çağırıyoruz ve p parametresini gönderiyoruz.
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)//eger olmazsa hata
				{
					//ModelState'e hata mesajlarını ekliyoruz.
					//item.PropertyName, hata mesajının hangi property'e ait olduğunu belirtir.
					//item.ErrorMessage, hata mesajını içerir.
					//ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					//ModelState'e hata mesajlarını ekliyoruz.
					//item.PropertyName, hata mesajının hangi property'e ait olduğunu belirtir.
					//item.ErrorMessage, hata mesajını içerir.

					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//ModelState'e hata mesajlarını ekliyoruz.
				}
			}
			return View();
		}
		public IActionResult DeleteProduct(int id)//ürün silme işlemi
		{
			var value = productManager.TGetById(id);//productManager sınıfından TGetById metodunu çağırıyoruz ve id parametresini gönderiyoruz.
			productManager.TDelete(value);//productManager sınıfından TDelete metodunu çağırıyoruz ve productValue parametresini gönderiyoruz.
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateProduct(int id)//ürün güncelleme işlemi
		{
			var value = productManager.TGetById(id);//productManager sınıfından TGetById metodunu çağırıyoruz ve id parametresini gönderiyoruz.
			return View(value);//value değişkenini View'a gönderiyoruz.
		}
		[HttpPost]
		public IActionResult UpdateProduct(Product p)
		{
			//var value = productManager.TGetById(p.Id);//productManager sınıfından TGetById metodunu çağırıyoruz ve p.Id parametresini gönderiyoruz.
			productManager.TUpdate(p);//productManager sınıfından TUpdate metodunu çağırıyoruz ve p parametresini gönderiyoruz.
			return RedirectToAction("Index");
		}
	}
}
