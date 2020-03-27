using System;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Core.Models
{
    public class BaseEntity
    {
               [Key]
               public long Id { get; set; }

}
}
