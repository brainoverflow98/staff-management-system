using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Controllers.Resources
{
    public class YetkilendirmeListResource
    {   [Required,MinLength(1)]
        public string username { get; set; }
        [Required,MinLength(1)]
        public string role { get; set; }

    }
}
