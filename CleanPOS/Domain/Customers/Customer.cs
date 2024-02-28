using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer: AggregateRoot
{
    public Customer(CustomerId id, string name, string lastname, string email, PhoneNumber phone, Address address, bool active )
    {
        Id= id;
        Name = name;
        LastName = lastname;
        Email = email;
        PhoneNumber = phone;
        Address = address;
        Active = active;
    }

    private Customer(){

    }

    public CustomerId Id { get; set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FullName => $"{LastName}, {Name}";
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set;}
    public Address Address { get; private set;}
    public bool Active { get; private set; }

}