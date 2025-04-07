using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	/*IProductService uzerinden ProductManagere miras verdik*/
	public class ProductManager : IProductService
	{
		// Burada IProductService'den gelen metotları implement ettik
		IProductDal _productDal;

		//bunun adı constructor metodudur turkcesı yapıcı metoddur
		public ProductManager(IProductDal productDal)//producttaki repositoryler ile haberlesmesi icin yazılıyor
		{
			_productDal = productDal;
		}
		public void TDelete(Product t)
		{
			_productDal.Delete(t);//productdal'daki delete metodunu çağırıyoruz
		}
		public Product TGetById(int id)
		{
			return _productDal.GetById(id);//productdal'daki getbyid metodunu çağırıyoruz
		}
		public List<Product> TGetList()
		{
			return _productDal.GetList();//productdal'daki getlist metodunu çağırıyoruz
		}
		public void TInsert(Product t)
		{
			_productDal.Insert(t);//productdal'daki insert metodunu çağırıyoruz

		}
		public void TUpdate(Product t)
		{
			_productDal.Update(t);//productdal'daki update metodunu çağırıyoruz
		}
	}
}
