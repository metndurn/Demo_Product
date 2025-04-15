using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Job//burada yeni tablo eklenip iliski kuruldu
	{
		public int JobId { get; set; }
		public string Name { get; set; }
		public List<Customer> Customers { get; set; }//bire cok iliski olacagı ıcın yazıldı
	}
}
