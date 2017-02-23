using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace ASPWebFormDapperDemo.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDbConnection _db;

        public CustomerRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerInformation"].ConnectionString);
        }
        
        public List<Customer> GetAll()
        {
            return this._db.Query<Customer>("SELECT * From Customer;").ToList();
        }

        public Customer FindById(int Id)
        {
            return this._db.Query<Customer>("SELECT * FROM Customer WHERE CustomerID=@Id", new { Id = Id }).FirstOrDefault();
        }

        public bool AddCustomer(Customer customer)
        {
            SqlParameter[] parameters = {
                            new SqlParameter("@CompanyName",customer.CompanyName),      
                            new SqlParameter("@Address",customer.Address),
                            new SqlParameter("@City",customer.City),
                            new SqlParameter("@State",customer.State),
                            new SqlParameter("@IntroDate",customer.IntroDate),
                            new SqlParameter("@CreditLimit",customer.CreditLimit)};

            string query = "INSERT INTO Customer(CompanyName,Address,City,State,IntroDate,CreditLimit)" 
                          + " Values(@CompanyName,@Address,@City,@State,@IntroDate,@CreditLimit)";

            var args = new DynamicParameters(new { });
            parameters.ToList().ForEach(p => args.Add(p.ParameterName, p.Value));
            try
            {
                this._db.Query<Customer>(query, args).SingleOrDefault();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateCustomer(Customer customer)
        {
            SqlParameter[] parameters = {
                            new SqlParameter("@CustomerID",customer.CustomerID),
                            new SqlParameter("@CompanyName",customer.CompanyName),      
                            new SqlParameter("@Address",customer.Address),
                            new SqlParameter("@City",customer.City),
                            new SqlParameter("@State",customer.State),
                            new SqlParameter("@IntroDate",customer.IntroDate),
                            new SqlParameter("@CreditLimit",customer.CreditLimit)};

            string query = " UPDATE Customer SET CompanyName = @CompanyName,Address = @Address, "
                         + " City = @City,State = @State,IntroDate = @IntroDate,CreditLimit = @CreditLimit"
                         + " WHERE CustomerID = @CustomerID";

            var args = new DynamicParameters(new { });
            parameters.ToList().ForEach(p => args.Add(p.ParameterName, p.Value));
            try
            {
                this._db.Execute(query, args);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteCustomer(int Id)
        {
            int deletedCustomer = this._db.Execute("DELETE FROM Customer WHERE CustomerID = @Id", new { Id = Id });
            return deletedCustomer > 0;
        }
    }
}