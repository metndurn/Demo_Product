using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	//veritabanı olusturulurken hangi katmanda yazdıysan o katmanda islem yapmalısın
	public class Context: DbContext//veritabanı baglantı yerlerı
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.;Database=ProjeOOP1;Trusted_Connection=true;TrustServerCertificate=True;");
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Customer> Customers { get; set; }
	}
}
