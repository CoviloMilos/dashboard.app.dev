using Advantage.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders.Include(o => o.Customer).OrderByDescending(c => c.Placed).AsQueryable();
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == id);
        }

        public Order CreateOrder(OrderForCreateDto orderForCreateDto)
        {
            var orderToInsert = new Order
            {
                Customer = _context.Customers.FirstOrDefault(c => c.Id == orderForCreateDto.CustomerId),
                Total = orderForCreateDto.Total,
                Placed = orderForCreateDto.Placed,
                Completed = orderForCreateDto.Completed
            };

            var result = _context.Add(orderToInsert);
            return result.Entity;
        }

        public IQueryable<Server> GetServers()
        {
            return _context.Servers.AsQueryable();
        }

        public void ChangeServerStatus(int id)
        {
            var server = _context.Servers.FirstOrDefault(s => s.Id == id);
            server.IsOnline = !server.IsOnline;
            Console.WriteLine("server-status changed to: " + server.IsOnline);
        }
    }
}