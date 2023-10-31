using ACME.LearningPlatform.API.Profiles.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StreetAddress Address { get; private set; }
    
    public Profile(string firstName, string lastName, string email, string street, string number, string city, string state, string zipCode, string country)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, number, city, state, zipCode, country);
    }

    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }
}