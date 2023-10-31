namespace ACME.LearningPlatform.API.Profiles.Domain.Model.ValueObjects;

public record StreetAddress(string Street, string Number, string City, string State, string ZipCode, string Country)
{
    public StreetAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street) : this(street, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string number) : this(street, number, string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string city, string state) : this(street,string.Empty,  city, state, string.Empty, string.Empty)
    {
    }
    
    public string FullAddress => $"{Street}, {Number }{City}, {State}, {ZipCode} {Country}";
}