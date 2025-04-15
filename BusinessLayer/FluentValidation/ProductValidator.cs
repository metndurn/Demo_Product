using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
	/*fluentvalidation kullanımı asagıdadır */
	public class ProductValidator : AbstractValidator<Product>
	{
		/*burada bu rol uzerıne kosullar eklendı bunun sebebı ilgili kontrollerda birden 
		 fazla if else yada birden fazla kosullu kod yazmaktan cok daha iyi oldugu ıcın 
		bunlar yazıldı*/
		public ProductValidator()//generic constructor metodu yani yapıcı metod demektır
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez.");
			RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.");
			RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez.");
			RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok miktarı boş geçilemez.");
		}

		public ValidationResult Validate(Customer c)
		{
			throw new NotImplementedException();
		}
	}
}
