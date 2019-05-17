using System;
using System.Collections.Generic;
using System.Linq;
using Advantage.API.Helpers;
using Advantage.API.Models;

namespace Advantage.API.Data
{
    public class DataSeed
    {
        private readonly DataContext _context;

        public DataSeed(DataContext context)
        {
           _context = context;
        }

        public void SeedData(int nCustomers, int nOrders) 
        {
            if (!_context.Customers.Any())
            {
                SeedCustomers(nCustomers);
                _context.SaveChanges();
            }

            if (!_context.Servers.Any())
            {
                SeedServers();
                _context.SaveChanges();
            }

            if (!_context.Orders.Any())
            {
                SeedOrders(nOrders);
                _context.SaveChanges();
            }

            
        }

        private void SeedServers()
        {
            List<Server> servers = BuildServerList();

            foreach (var server in servers)
            {
                _context.Servers.Add(server);
            }
        }

        private void SeedOrders(int nOrders)
        {
            List<Order> orders = BuildOrderList(nOrders);

            foreach (var order in orders)
            {
                _context.Orders.Add(order);
            }
        }

        private void SeedCustomers(int nCustomers)
        {
            List<Customer> customers = BuildCustomerList(nCustomers);

            foreach (var customer in customers)
            {
                _context.Customers.Add(customer);
            }
        }

        private List<Server> BuildServerList() 
        {
            return new List<Server>()
            {
                new Server()
                {
                    Name = "Dev-Web",
                    IsOnline = true
                },
                new Server()
                {
                    Name = "Dev-Mail",
                    IsOnline = false
                },
                new Server()
                {
                    Name = "Dev-Services",
                    IsOnline = true
                },
                new Server()
                {
                    Name = "QA-Web",
                    IsOnline = false
                },
                new Server()
                {
                    Name = "QA-Mail",
                    IsOnline = true
                },
                new Server()
                {
                    Name = "QA-Services",
                    IsOnline = false
                },
                new Server()
                {
                    Name = "Prod-Web",
                    IsOnline = true
                },
                new Server()
                {
                    Name = "Prod-Mail",
                    IsOnline = false
                },
                new Server()
                {
                    Name = "Prod-Services",
                    IsOnline = true
                }
            };
        }
        private List<Order> BuildOrderList(int nOrders) 
        {
            var orders = new List<Order>();
            var rand = new Random();


            for (var i = 0; i < nOrders; i++)
            {
                var customers = _context.Customers.ToList();
                Console.WriteLine("JEGENDO:" + customers[0].Id);
                var randCustomerId = rand.Next(customers[0].Id, customers[customers.Count-1].Id);
                var placed = SeedCustProp.GetRandomOrderPlacedSeed();
                var completed = SeedCustProp.GetRandomOrderCompletedSeed(placed);
                

                orders.Add(new Order{
                    Customer = customers.First(c => c.Id == randCustomerId),
                    Total = SeedCustProp.GetRandomOrderTotalSeed(),
                    Placed = placed,
                    Completed = completed
                });
            }

            return orders;
        }
        private List<Customer> BuildCustomerList(int nCustomers) 
        {
            var customers = new List<Customer>();
            var names = new List<string>();

            for(var i = 0; i < nCustomers; i++)
            {
                var name = SeedCustProp.MakeUniqueCustomerNameSeed(names);
                names.Add(name);
                customers.Add(new Customer {
                    Name = name,
                    Email = SeedCustProp.MakeCustomerEmailSeed(name),
                    State = SeedCustProp.GetRadnomStateSeed(),
                    CustomerRole = SeedCustProp.GetRandomRoleSeed()
                });
            }

            return customers;
        }
    }
}