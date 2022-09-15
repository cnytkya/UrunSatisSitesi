using System.ComponentModel.DataAnnotations;

namespace UrunSatisSitesi.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Soyad"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "{0} Boş Geçilemez!"), EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} Boş Geçilemez!"), DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
