using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebFormDapperDemo.Models
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer FindById(int Id);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int Id);
    }
}