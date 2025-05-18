using System;
using System.ComponentModel.DataAnnotations;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class Kullanici
    {
        public Guid Id { get; set; }
        public string IdentityUserId { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih giriniz.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DogumTarihi { get; set; }

        [StringLength(10, ErrorMessage = "Cinsiyet en fazla 10 karakter olabilir.")]
        public string Cinsiyet { get; set; }

        [StringLength(200, ErrorMessage = "Adres en fazla 200 karakter olabilir.")]
        public string Adres { get; set; }

        [StringLength(50, ErrorMessage = "Sigorta durumu en fazla 50 karakter olabilir.")]
        public string SigortaDurumu { get; set; }
    }
}