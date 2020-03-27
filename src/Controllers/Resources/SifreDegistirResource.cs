using System;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Controllers.Resources
{
    public class SifreDegistirResource
    {


          
            [Required(ErrorMessage = "Şifre gereklidir")]
            [StringLength(100, ErrorMessage = " {0} En az {2} ve en fazla {1} karekter olmalıdır.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string guncelSifre { get; set; }

            [DataType(DataType.Password,ErrorMessage="Şifr")]
            public string yeniSifre { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Şifreyi Tekrar giriniz")]
            [Compare("yeniSifre", ErrorMessage = "Şifreler eşleşmiyor.")]
            public string tekrarYeniSifre { get; set; }


    }

}

