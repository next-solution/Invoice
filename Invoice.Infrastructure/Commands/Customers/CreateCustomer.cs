namespace Invoice.Infrastructure.Commands.Customers
{
    public class CreateCustomer : ICommand
    {
        public int Nip { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email {get; set; }
    }
}