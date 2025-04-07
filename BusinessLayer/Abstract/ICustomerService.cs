using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICustomerService : IGenericService<Customer>
	{
		// Buraya müşteriyle ilgili özel metotlar eklenebilir
		// Örneğin, müşteri bilgilerini güncelleme, müşteri arama vb.
		// Ancak şu an için sadece GenericService'den miras alıyoruz.
		// Bu kısım ileride genişletilebilir.
	}
}
