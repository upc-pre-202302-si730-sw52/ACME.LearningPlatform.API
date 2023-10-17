using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial: Asset
{
    public Tutorial():base(EAssetType.Tutorial)
    {
        Title = string.Empty;
        Summary = string.Empty;
        Status = EAssetStatus.Draft;
        Assets = new List<Asset>();
    }
    
    
    public AcmeAssetIdentifier TutorialIdentifier => AssetIdentifier;
    
    private ICollection<Asset> Assets { get; }
    
    public override object GetContent()
    {
        throw new NotImplementedException();
    }

    public override bool Readable { get; }
    public override bool Viewable { get; }
}