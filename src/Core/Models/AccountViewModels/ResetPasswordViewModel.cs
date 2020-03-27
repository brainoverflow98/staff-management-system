using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakip.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage="Kullanıcı adı gereklidir")]
        public string Username { get; set; }
        [Required(ErrorMessage="Şifre gereklidir")]
        [StringLength(100, ErrorMessage = " {0} En az {2} ve en fazla {1} karekter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

    }
}
