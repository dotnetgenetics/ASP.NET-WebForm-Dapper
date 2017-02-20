using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebFormDapperDemo.Models
{
    public class CustomerService
    {
    
        ICustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public Customer FindById(int Id)
        {
            return _repository.FindById(Id);
        }

        public bool AddCustomer(Customer customer)
        {
            return _repository.AddCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _repository.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(int Id)
        {
            return _repository.DeleteCustomer(Id);
        }
    }
}