using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class HesaplamaUnvani
    {

        public long HesaplamaId { get; set; }
        public virtual Hesaplama Hesaplama { get; set; }

        public long UnvanId { get; set; }
        public virtual Unvan Unvan { get; set; }       

    }
}
