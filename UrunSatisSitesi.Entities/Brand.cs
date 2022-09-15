using System.ComponentModel.DataAnnotations;

namespace UrunSatisSitesi.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        public string? Logo { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set; } // Brand ile Product arasında bire çok ilişki kurduk
        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
