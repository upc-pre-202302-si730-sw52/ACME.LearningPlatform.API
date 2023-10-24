using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public class ImageAsset: Asset
{
    public Uri ImageUri { get; }

    public ImageAsset() : base(EAssetType.Image)
    {
        
    }
    public ImageAsset(string imageUrl) : base(EAssetType.Image)
    {
        ImageUri = new Uri(imageUrl);
    }

    public override string GetContent()
    {
        return ImageUri.AbsoluteUri;
    }

    public override bool Readable => false;
    public override bool Viewable => true;
}