using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	/*burası kontrollerın yapıldıgı yerdır yanı urun adı 20 karakterı gecmesın veya urun adını gıren
	 kısı muhakkak sıstemde kayıtlı bır yetkılı kısının olması lazım bu tur kısıtlamalar yapılacak*/
	public interface IGenericService<T>
	{
		void TInsert(T t);
		void TDelete(T t);
		void TUpdate(T t);
		T TGetById(int id);
		List<T> TGetList();
	}
}
