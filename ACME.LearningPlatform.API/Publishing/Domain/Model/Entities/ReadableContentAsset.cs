using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public class ReadableContentAsset: Asset
{
    private string ReadableContent { get; set; }
    
    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
        
    }
    public ReadableContentAsset(string content) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = content;
    }

    public override string GetContent()
    {
        return ReadableContent;
    }

    public override bool Readable => true;
    public override bool Viewable => false;
}