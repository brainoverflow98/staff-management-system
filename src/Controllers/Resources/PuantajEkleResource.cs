using System;
using System.Collections.Generic;

namespace PersonelTakip.Controllers.Resources
{
    public class PuantajEkleResource
    {
        public long uid { get; set; }
        public List<Cell> cells { get; set; }

        public class Cell
        {
            public String date { get; set; }
            public long value { get; set; }
        }       
      
    }
}