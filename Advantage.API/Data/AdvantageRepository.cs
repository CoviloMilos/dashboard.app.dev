using Advantage.API.Models;
using System.Linq;

namespace Advantage.API.Data
{
    public class AdvantageRepository :  IAdvantageRepository
    {
        private readonly DataContext _context;

        public AdvantageRepository(DataContext context)
        {
            _context = context;
        }

        public T Add<T>(T entity) where T : class
        {
            var result = _context.Add(entity);
            return result.Entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(c => c.Id).AsQueryable();
        }
        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}