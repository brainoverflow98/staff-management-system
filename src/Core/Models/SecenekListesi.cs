using System;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class SecenekListesi:BaseEntity
    {

        [MaxLength(3)]
        public string Deger { get; set; }

        [MaxLength(256)]
        public string Aciklama { get; set; }

        [MaxLength(50)]
        public string Renk { get; set; }

        public bool Disabled { get; set; }


    }
}
