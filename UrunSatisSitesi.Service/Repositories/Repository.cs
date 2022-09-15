using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UrunSatisSitesi.Data;
using UrunSatisSitesi.Entities;

namespace UrunSatisSitesi.Service.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new() // IRepository nin altı kızarınca üzerine gelin ampülden
    {
        private readonly DatabaseContext _databaseContext;
        DbSet<T> _dbSet;

        public Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<T>(); // Entity framework de veritabanı işlemleri dbset ler üzerinden yapılmakta, Repository design pattern de bu dbset leri <T> yapısı ile generic yani her class için dinamik olarak yapabilmek için
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return SaveChanges();
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public IQueryable<T> GetAllInclude(string table)
        {
            return _dbSet.Include(table);
        }

        public IQueryable<T> GetAllInclude(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Include(expression);
        }

        public int SaveChanges()
        {
            return _databaseContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _databaseContext.Update(entity);
        }
    }
}
