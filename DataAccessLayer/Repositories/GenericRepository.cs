using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	/*her bır entitylerin icini yazmak yerıne burada butun entityler icin yazıldı
	 entitylerin yerini T aldı bunuda unutma*/
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		public void Delete(T t)//silme metodu
		{
			using var c =new Context();
			c.Remove(t);
			c.SaveChanges();
		}
		public T GetById(int id)//id ye göre bulma metodu
		{
			using var c = new Context();
			return c.Set<T>().Find(id);
		}
		public List<T> GetList()//listeleme metodu
		{
			using var c = new Context();
			return c.Set<T>().ToList();
		}
		public void Insert(T t)//ekleme metodu
		{
			using var c = new Context();
			c.Add(t);
			c.SaveChanges();
		}
		public void Update(T t)//guncelleme metodu
		{
			using var c = new Context();
			c.Update(t);
			c.SaveChanges();
		}
	}
}
