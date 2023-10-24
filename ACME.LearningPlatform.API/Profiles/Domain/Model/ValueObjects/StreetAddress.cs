namespace ACME.LearningPlatform.API.Profiles.Domain.Model.ValueObjects;

public record StreetAddress(string Street, string City, string State, string ZipCode)
{
    public StreetAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street) : this(street, string.Empty, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string city) : this(street, city, string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string city, string state) : this(street, city, state, string.Empty)
    {
    }
    
    public string FullAddress => $"{Street}, {City}, {State}, {ZipCode}";
}