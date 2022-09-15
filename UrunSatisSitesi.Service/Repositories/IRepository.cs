
using System.Linq.Expressions; // Bu kütüphane linq sorgulamaları yapabilmemiz için gerekli

namespace UrunSatisSitesi.Service.Repositories
{
    public interface IRepository<T> where T : class // IRepository interface ine parametre olarak T(yani entity classlarından herhangi biri) gönderilmelidir. where T : class ise bu t nin bir class yani sınıf olma zorunluluğu getirir
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression); // expression parametresine ef de kullandığımız x=>x. şeklindeki lambda expression gönderebilmemizi sağlayacak
        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);
        int Add(T entity);
        void Update(T entity);
        int Delete(T entity);
        int SaveChanges();
        IQueryable<T> GetAllInclude(string table);
        IQueryable<T> GetAllInclude(Expression<Func<T, bool>> expression);
        // Asenkron Metotlar
        Task<T> FindAsync(int id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
