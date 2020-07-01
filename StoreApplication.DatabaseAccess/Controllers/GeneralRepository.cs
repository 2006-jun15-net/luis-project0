using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreApplication.DatabaseAccess.Model;
using System.Collections.Generic;
using StoreApplication.Library;
using System.Linq;


namespace StoreApplication.DatabaseAccess.Controllers

{
    
    public class GeneralRepository<T> : IRepository<T> where T : class
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static readonly DbContextOptions<storeapplicationContext> Options = new DbContextOptionsBuilder<storeapplicationContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;

        private storeapplicationContext _context = null;
        private DbSet<T> table = null;
        public GeneralRepository()
        {
            this._context = new storeapplicationContext();
            table = _context.Set<T>();
        }
        public GeneralRepository(storeapplicationContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table;
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Add(T obj)
        {
            table.Add(obj);
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}