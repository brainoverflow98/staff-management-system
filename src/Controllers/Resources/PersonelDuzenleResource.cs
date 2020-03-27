using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonelTakip.Controllers.Resources
{
    public class PersonelDuzenleResource
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad gereklidir\t")]
        [MaxLength(100)]
        public string AdSoyad { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "11 Haneli Tc Kimlik numarasını giriniz")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Lütfen sadece sayı giriniz")]
        [Required(ErrorMessage = "Tc kimlik numarası giriniz")]
        public string TcNo { get; set; }

        [Required(ErrorMessage = "Lütfen bir tarih giriniz")]
        [DataType(DataType.Date, ErrorMessage = "Lütfen düzgün formatta tarih giriniz")]
        public DateTime DogumTarihi { get; set; }

        public long GorevId { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(13, ErrorMessage = "Lütfen geçerli bir telefon numarası girin")]
        public string Telefon { get; set; }

        [MaxLength(10, ErrorMessage = "Lütfen listeden bir değer seçiniz")]
        public string KanGrubu { get; set; }

        [MaxLength(250)]
        public string Adres { get; set; }

        [MaxLength(7, ErrorMessage = "Lütfen geçerli bir sicil numarası girin")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Lütfen sadece sayı giriniz")]
        public string SicilNo { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Lütfen düzgün formatta tarih giriniz")]
        [Required(ErrorMessage = "Lütfen bir tarih giriniz")]
        public DateTime IseBaslamaTarihi { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Lütfen düzgün formatta tarih giriniz")]
        public DateTime? IstenAyrilmaTarihi { get; set; }

        public IFormFile PersonelFotgrafi { get; set; }
    }

}
