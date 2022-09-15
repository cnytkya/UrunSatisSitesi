using System.ComponentModel.DataAnnotations;

namespace UrunSatisSitesi.Entities
{
    public class AppUser : IEntity
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
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }
        [Display(Name = "Şifre"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Password { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn(false) sayfa oluştururken ekranda bu alan oluşmasın diye
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
