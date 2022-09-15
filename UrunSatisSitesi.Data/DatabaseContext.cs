using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UrunSatisSitesi.Data.Configurations;
using UrunSatisSitesi.Entities;

namespace UrunSatisSitesi.Data
{
    // Bu sınıfda entity framework kullanacağımız için Solution kısmından UrunSatisSitesi.Data projesine sağ tıklayıp manage nuget packages menüsüne tıklıyoruz. açılan pencerede Browse sekmesine tıklayıp " Microsoft.EntityframeworkCore, Microsoft.EntityframeworkCore.Design, Microsoft.EntityframeworkCore.SqlServer, Microsoft.EntityframeworkCore.Tools " paketlerini install deyip gelen uyarıyı accept ile kabul ederek yüklüyoruz.
    public class DatabaseContext : DbContext
    {
        // ctor yazıp klavyeden tab tab diyerek oluşturabiliriz
        //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{

        //}
        // Katmanlı mimaride bir katman (UrunSatisSitesi.Data katmanı gibi) başka bir katmana erişecekse bunu solution kısmından projenin altındaki dependencies bölümüne sağ tıklayıp add project reference diyerek açılan pencereden ilgili katmanı (UrunSatisSitesi.Entities gibi) yandaki check e tik koyarak kaydet deyip işlemi tamamlayabiliriz. Veya aşağıda yaptığımız gibi Appuser db set inin yazıp çıkan ampulden add project reference menüsüne tıklayıp bu işlemin otomatik yapılmasını sağlayabiliriz yalnız bu noktada dikkate etmemiz gereken nokta yazım yanlışı yapmamak! visual studio bulamayabilir yanlış yazarsak.
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        // Dbset leri oluşturduktan sonra aşağıdaki metodu override yazıp bir boşluk bırakıp on yazıp gelen seçeneklerden OnConfiguring i seçip enter a basarak oluşturuyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Burada optionsBuilder ı kullanarak sql server ayarlarımızı belirleyebiliyoruz
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=UrunSatisSitesi; trusted_connection=true;"); // bu metot ile uygulamada sql server kullanacağımızı belirttik
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FluentAPI : Data annotations taki tablo ve property özelliklerini yapılandırabileceğimiz bir diğer yöntemdir.
            modelBuilder.Entity<AppUser>().Property(a => a.Name) // Entitilerimizden appuser ın propertylerinden Name alanı için 
                .IsRequired() // Bu property i zorunlu alan yap
                .HasColumnType("varchar(50)") // Name alanının sql deki kolon tipi varchar(50) olsun
                .HasMaxLength(50) // Kolon karakter uzuluğu
                ;
            modelBuilder.Entity<AppUser>().Property(s => s.Surname).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(s => s.Email).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Entity<AppUser>().Property(p => p.Phone).HasColumnType("varchar(15)");
            modelBuilder.Entity<AppUser>().Property(un => un.Username).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<AppUser>().Property(p => p.Password).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
            // FluentAPI ile veritabanı oluştuktan sonra ilk kaydı ekleme
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    Username = "Admin",
                    Password = "123",
                    Email = "admin@urunsatissitesi.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Admin",
                    Surname = "Administrator"
                });
            //modelBuilder.ApplyConfiguration(new BrandConfiguration()); // Marka yapılandırma ayarlarını bu şekilde modelbuilder a göstermemiz gerekli

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Otomatik olarak projedeki tüm configurationları ekliyor

            base.OnModelCreating(modelBuilder);
        }

    }
}
