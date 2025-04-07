using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICategoryService : IGenericService<Category>
	{
		// Buraya kategoriyle ilgili özel metotlar eklenebilir
		// Örneğin, kategoriye ürün ekleme, kategori silme vb.
		// Ancak şu an için sadece GenericService'den miras alıyoruz.
		// Bu kısım ileride genişletilebilir.
		// Örnek: List<Category> GetCategoriesByProductId(int productId);
	}
}
