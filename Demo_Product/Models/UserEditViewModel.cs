using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
	public class UserEditViewModel
	{
		[Required(ErrorMessage = "Lutfen isim giriniz..")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Lutfen soyisim giriniz..")]
		public string SurName { get; set; }

		[Required(ErrorMessage = "Lutfen cinsiyet giriniz..")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "Lutfen email adresi giriniz..")]
		public string EMail { get; set; }

		[Required(ErrorMessage = "Lutfen sifre giriniz..")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lutfen sifreyi tekrar giriniz..")]
		[Compare("Password", ErrorMessage = "Lutfen siflerin eslestiginden emin olun..")]
		public string ConfirmPassword { get; set; }
	}
}
