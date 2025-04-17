using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
	public class UserLoginViewModel//kullanıcı gırıs bılgılerının modelı
	{
		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
		public string Password { get; set; }
	}
}
