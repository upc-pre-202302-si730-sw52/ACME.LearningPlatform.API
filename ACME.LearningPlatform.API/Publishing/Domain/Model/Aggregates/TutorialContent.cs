using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial
{
    public AcmeAssetIdentifier TutorialIdentifier { get; private set; }
}