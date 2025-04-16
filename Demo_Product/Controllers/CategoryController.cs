using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
	public class CategoryController : Controller
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		public IActionResult Index()
		{
			var values = categoryManager.TGetList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCategory(Category c)
		{
			CategoryValidator validationRules = new CategoryValidator();
			ValidationResult result = validationRules.Validate(c);
			if (result.IsValid)//kosul koyduk 
			{
				categoryManager.TInsert(c);
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
		public IActionResult DeleteCategory(int id)
		{
			var value = categoryManager.TGetById(id);
			categoryManager.TDelete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateCategory(int id)
		{
			var value = categoryManager.TGetById(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateCategory(Category c)
		{
			categoryManager.TUpdate(c);
			return RedirectToAction("Index");
		}
	}
}
