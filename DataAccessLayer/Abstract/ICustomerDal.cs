using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	//IGenericDal'daki T parametresini Customer class'ı ile doldurduk
	public interface ICustomerDal : IGenericDal<Customer>
	{
		List<Customer> GetCustomerListWithJob();//job tablosu ile customer tablosunu birleştirip listeleme bunun dıger adı join
	}
}
