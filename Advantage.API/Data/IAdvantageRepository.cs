using System.Linq;
using Advantage.API.Models;

namespace Advantage.API.Data
{
    public interface IAdvantageRepository
    {
        T Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        bool SaveAll();
        Customer GetCustomer(int id);
        IQueryable<Customer> GetCustomers();
        IQueryable<Order> GetOrders();
        Order GetOrder(int id);
        Order CreateOrder(OrderForCreateDto orderForCreateDto);
        IQueryable<Server> GetServers();
        void ChangeServerStatus(int id);
    }
}