using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class Unvan:BaseEntity
    {

        [MaxLength(100)]
        public string UnvanAdi { get; set; }        

        public bool Disabled { get; set; }

        public virtual ICollection<Personel> Personeller { get; set; }
    }
}
