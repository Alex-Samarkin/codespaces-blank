
namespace StatsLibrary;
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public Person(string firstName, string lastName, string email, string phoneNumber, string address, string city, string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public Person()
    {

    }
    /// copy constructor
    public Person(Person person)
    {
        FirstName = person.FirstName;
        LastName = person.LastName;
        Email = person.Email;
        PhoneNumber = person.PhoneNumber;
        Address = person.Address;
        City = person.City;
        State = person.State;
        ZipCode = person.ZipCode;
    }
    /// equality operator
    public static bool operator ==(Person person1, Person person2)
    {
        return person1.Equals(person2);
    }
    /// inequality operator
    public static bool operator !=(Person person1, Person person2)
    {
        return !person1.Equals(person2);
    }   
    /// override Equals
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj.GetType() != this.GetType())
        {
            return false;
        }
        Person person = (Person)obj;
        return (FirstName == person.FirstName) && (LastName == person.LastName) && (Email == person.Email) && (PhoneNumber == person.PhoneNumber) && (Address == person.Address) && (City == person.City) && (State == person.State) && (ZipCode == person.ZipCode);
    }
    /// override GetHashCode
    public override int GetHashCode()
    {
        return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ Email.GetHashCode() ^ PhoneNumber.GetHashCode() ^ Address.GetHashCode() ^ City.GetHashCode() ^ State.GetHashCode() ^ ZipCode.GetHashCode();
    }
    /// override ToString
    public override string ToString()
    {
        return $"{FirstName} {LastName} {Email} {PhoneNumber} {Address} {City} {State} {ZipCode}";
    }


}