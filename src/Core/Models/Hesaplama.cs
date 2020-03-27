using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class Hesaplama:BaseEntity
    {

        [MaxLength(100)]
        public string Baslik { get; set; }        

        public bool OzetGoster { get; set; }

        public int SaymaLimiti { get; set; }

        public int UyariLimiti { get; set; }

        public bool Disabled { get; set; }

        public virtual ICollection<HesaplamaSecenegi> HesaplamaSecenekleri { get; set; }

        public virtual ICollection<HesaplamaUnvani> HesaplamaUnvanlari { get; set; }

    }
}
