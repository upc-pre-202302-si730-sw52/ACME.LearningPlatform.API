namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public record AcmeAssetIdentifier(Guid Identifier)
{
    public AcmeAssetIdentifier() : this(Guid.NewGuid())
    {
    }
}