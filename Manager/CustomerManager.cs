using static Model.CustomerModel;

namespace Manager.CustomerManager
{
    public class CustomerManager : ICustomerService
    {
        // Temporary data for testing before database connections
        private readonly List<Customer> _students = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Doe", Age = 18 },
            new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Age = 19 }
        };

        // Function that displays all students within the list
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _students;
        }

        // Function to display the details of the student if there is a matching Id
        public Customer GetCustomerById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        // Function that adds a student to the list
        public void AddCustomer(Customer customer)
        {
            customer.Id = _students.Max(s => s.Id) + 1;
            _students.Add(customer);
        }

        // Function that updates a student's information if it exists
        public void UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = _students.FirstOrDefault(s => s.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Age = customer.Age;
            }
        }

        // Function that deletes a student from the list
        public void DeleteCustomer(int id)
        {
            var customer = _students.FirstOrDefault(s => s.Id == id);
            if (customer != null)
            {
                _students.Remove(customer);
            }
        }
    }

    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer customer);
        void DeleteCustomer(int id);
    }

    // Assume Customer class is defined in Model.CustomerModel
}
