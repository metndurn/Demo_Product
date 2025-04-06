using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	/*product sınıfına aıt crud ıslemlerının metodlarını tanımlayabılırız*/
	//IGenericDal'daki T parametresini Customer class'ı ile doldurduk
	public interface IProductDal : IGenericDal<Product>//generic dal ı implement ettık
	{
		
	}
}
