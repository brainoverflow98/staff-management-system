using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class HesaplamaSecenegi
    {

        public long SecenekId { get; set; }
        public virtual SecenekListesi Secenek { get; set; }

        public long HesaplamaId { get; set; }
        public virtual Hesaplama Hesaplama { get; set; }

        public int Katsayi { get; set; } = 1;

    }
}
