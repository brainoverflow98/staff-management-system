using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class Personel:BaseEntity
    {

        [MaxLength(100)]
        public string AdSoyad { get; set; }
    
        [MaxLength(11),MinLength(11)]


        public string TcNo { get; set; }

        public DateTime DogumTarihi { get; set; }

        public long GorevId { get; set; }
        public virtual Unvan Gorev { get; set; }

        [MaxLength(20)]

        public string Telefon { get; set; }

        [MaxLength(10)]

        public string KanGrubu { get; set; }

        [MaxLength(256)]

        public string Adres { get; set; }

        [MaxLength(7)]
        public string SicilNo { get; set; }

        public DateTime IseBaslamaTarihi { get; set; }

        public DateTime IstenAyrilmaTarihi { get; set; }


        public virtual ICollection<PuantajGirdisi> PuantajGirdileri  { get; set; }

    }
}
