using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IProductService:IGenericService<Product>
	{
		// Buraya ürünle ilgili özel metotlar eklenebilir
		// Örneğin, ürünün fiyatını güncelleme, stok kontrolü yapma vb.
		// Ancak şu an için sadece GenericService'den miras alıyoruz.
		// Bu kısım ileride genişletilebilir.
	}
}
