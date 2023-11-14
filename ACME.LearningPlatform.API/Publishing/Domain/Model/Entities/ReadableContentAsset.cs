using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public class ReadableContentAsset : Asset
{
    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
    }

    public ReadableContentAsset(string content) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = content;
    }

    private string ReadableContent { get; }

    public override bool Readable => true;
    public override bool Viewable => false;

    public override string GetContent()
    {
        return ReadableContent;
    }
}