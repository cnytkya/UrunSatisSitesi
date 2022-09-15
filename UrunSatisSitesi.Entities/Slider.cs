using System.ComponentModel.DataAnnotations;

namespace UrunSatisSitesi.Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string? Title { get; set; }
        [Display(Name = "Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Resim Link")]
        public string? Link { get; set; }
    }
}
