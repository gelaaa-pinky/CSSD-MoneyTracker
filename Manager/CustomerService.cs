using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.CustomerModel;

namespace Manager.CutsomerService
{
    public interface ICustomerService
    {
        IEnumerable<Customer>GetAllStudents();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer customer);
        void DeleteCustomer(int id);
        object? GetAllCustomer();
    }
}