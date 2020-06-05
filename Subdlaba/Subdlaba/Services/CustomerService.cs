using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subdlaba.Interface;
using Subdlaba.Models;
using Microsoft.EntityFrameworkCore;

namespace Subdlaba.Services
{
    public class CustomerService : ILogic<Customer>
    {
        private static TaskTrackerDatabase db = Program.db;

        public void Create(Customer model)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Username == model.Username);
            if (customer != null)
            {
                throw new Exception("Такой пользователь уже есть");
            }
            db.Customers.Add(model);
            db.SaveChanges();
        }

        public void Delete(Customer model)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == model.Id);
            if (customer == null)
            {
                throw new Exception("Такого пользователя нет");
            }
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        public void Update(Customer model)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == model.Id);
            if (customer == null)
            {
                throw new Exception("Такого пользователя нет");
            }
            customer.Username = model.Username;
            db.SaveChanges();
        }
        public List<Customer> Read()
        {
            return db.Customers.ToList();
        }
        public void ReadPage(int strCount, int strSkip)
        {
            var _event = from n in db.Customers.Skip(strSkip).Take(strCount)
                         select new
                         {
                             n.Id,
                             n.Username,
                             n.Email
                         };
            foreach (var c in _event)
            {
                Console.WriteLine(c.Username + " " + c.Email);
            }
        }

        public Customer Get(int Id)
        {
            return db.Customers.FirstOrDefault(c => c.Id == Id);
        }

        public void ZaprosCustomerProject()
        {
            var customers = db.Projects
                .Join(db.Customers,
                c => c.Id,
                s => s.Id,
                (c, s) => new
                {
                    s.Username,
                    c.Name
                });
            foreach (var c in customers)
            {
                Console.WriteLine(c.Username + " " + c.Name);
            }
        }
        public void CreateCustomer(string Username, string Email, int ProjectId)
        {
            Customer customer = new Customer()
            {
                Username = Username,
                Email = Email,
                ProjectId = ProjectId
            };
            Create(customer);
        }
        public void DeleteCustomer(int Id, string Username, string Email, int ProjectId)
        {
            Customer customer = new Customer()
            {
                Id = Id,
                Username = Username,
                Email = Email,
                ProjectId = ProjectId
            };
            Delete(customer);
        }
        public void UpdateCustomer(int Id, string Username, string Email, int ProjectId)
        {
            var list = Get(Id);
            Customer customer = new Customer()
            {
                Id = list.Id,
                Username = Username,
                Email = Email,
                ProjectId = ProjectId
            };
            Update(customer);
        }
        public void ReadCustomer()
        {
            var list = Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Id + " " + p.Username + " " + p.Email + " " + p.ProjectId);
            }
        }
    }
}
