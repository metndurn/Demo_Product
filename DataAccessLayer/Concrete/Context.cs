using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	//veritabanı olusturulurken hangi katmanda yazdıysan o katmanda islem yapmalısın
	//aslında ısın ozu identitydbcontext sınıfı zaten dbcontext sınıfından mıras alıyor
	//ilk başta dbcontext kullanıldı daha sonra identitydbcontext kullanıldı
	public class Context: IdentityDbContext<AppUser,AppRole,int>//dbcontext ile veritabanı baglantı yerlerı appuser ve approle sınıflarıyla baglanır
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.;Database=ProjeOOP1;Trusted_Connection=true;TrustServerCertificate=True;");
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Job> Jobs { get; set; }
	}
}
