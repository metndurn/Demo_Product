using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	/*burada dıger sınıflardakı butun yapıyı olabıldıgınce toplu hale getırıp kullanıyoruz
	 yani IGenericDal adında interface olusturup T adında parametre tanımlayıp class'lara nereden
	ulasması grerektıgını soyluyoruz ve dogrudan buradakı metod yapısının yolunu verdık
	dipnot T nin verilmesinin en buyuk sebebi onun bir entity olmasıdır yani T esittir entity demektir*/
	public interface IGenericDal<T> where T : class
	{
		void Insert(T t);//ekleme metodu
		void Update(T t);//guncelleme metodu
		void Delete(T t);//silme metodu
		List<T> GetList();//listeleme metodu
						  
		T GetById(int id);//id ye göre bulma metodu
	}
}
