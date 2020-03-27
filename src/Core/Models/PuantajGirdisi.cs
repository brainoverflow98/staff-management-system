using System;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class PuantajGirdisi
    {
        [Key]
        public long PersonelId { get; set; }
        public virtual Personel Personel { get; set; }

        [Key]
        public DateTime Tarih { get; set; }

        public long SecenekId { get; set; }
        public virtual SecenekListesi Secenek { get; set; }

    }
}
