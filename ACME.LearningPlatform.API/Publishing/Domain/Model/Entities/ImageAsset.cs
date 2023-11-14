using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public class ImageAsset : Asset
{
    public ImageAsset() : base(EAssetType.Image)
    {
    }

    public ImageAsset(string imageUrl) : base(EAssetType.Image)
    {
        ImageUri = new Uri(imageUrl);
    }

    public Uri ImageUri { get; }

    public override bool Readable => false;
    public override bool Viewable => true;

    public override string GetContent()
    {
        return ImageUri.AbsoluteUri;
    }
}