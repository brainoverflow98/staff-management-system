using System;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class YillikIzin
    {
        [Key]
        public long PersonelId { get; set; }

        [Key]
        public DateTime Tarih { get; set; }

        public int IzinHakki { get; set; }

        public int KullanilanIzin { get; set; }

        public int KalanIzin { get; set; }

    }
}
