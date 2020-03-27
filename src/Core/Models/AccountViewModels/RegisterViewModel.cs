using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakip.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="Kullanıcı adı gereklidir")]
        [MinLength(length:1,ErrorMessage ="Kullanıcı adı boş girilemez")]
        [Display(Name = "username")]
        public string username { get; set; }

        [Required(ErrorMessage="Şifre gereklidir")]
        [StringLength(100, ErrorMessage = " Şifre en az {0} en fazla {2} karekter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor tekrar giriniz.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage="Rol gereklidir")]
        [MinLength(length: 1, ErrorMessage = "Rol  boş girilemez")]
        public string Role { get; set; }
    }
}
