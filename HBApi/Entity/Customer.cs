namespace HBApi.Entity
{
    public class Customer
    {
        public Customer(int id, string? name, string? email, string? address, string? phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public string? Address { get; private set; }

        public string? PhoneNumber { get; private set; }

        public void UpdateCustomerName(string newCustomerName)
        {
            // validation
            Name = newCustomerName;
        }
    }
}