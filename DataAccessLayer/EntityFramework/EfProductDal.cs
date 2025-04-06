using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	/*buranın kullanım amacı burada sadece buraya aıt metodlar tanımlanabılınır dıye var*/
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
	}
}
