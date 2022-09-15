namespace UrunSatisSitesi.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}

// Katmanlı mimari sisteminde katman oluşturmak için Solution a sağ tıklayıp Add > new project menüsünden Açılan pencerede Filtre kısmından " c# - windows - Library " seçeneklerini seçerek aşağıdaki listeden Class Library proje türünü seçip Next diyoruz. 
// Gelen ekranda projeye bir isim veriyoruz (UrunSatisSitesi.Entities) gibi. Sonrasında .net 6 sürümünü seçip create diyerek projeyi oluşturuyoruz.

/*
 * Veritabanı ilişki türleri
 * 1 e 1 ilişki : Mesela 1 markanın sadece 1 tane ürünü olabilir
 * 1 e çok ilişki : 1 Markanın veya kategorinin 1 den çok ürünü olabilir
 * Çoka çok ilişki : 1 kategorinin 1 den çok ürünü olabilir, 1 ürünün 1 den çok kategorisi olabilir
 */