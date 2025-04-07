using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
		public IActionResult AddProduct(Product p)//ürün ekleme işlemi
		{
			productManager.TInsert(p);//productManager sınıfından TInsert metodunu çağırıyoruz ve p parametresini gönderiyoruz.
			return RedirectToAction("Index");
		}
	}
}
