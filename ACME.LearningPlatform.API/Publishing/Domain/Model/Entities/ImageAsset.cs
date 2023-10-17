using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public class ImageAsset: Asset
{
    private Uri ImageUrl { get; }
    
    public ImageAsset(string imageUrl) : base(EAssetType.Image)
    {
        ImageUrl = new Uri(imageUrl);
    }

    public override string GetContent()
    {
        return ImageUrl.AbsoluteUri;
    }

    public override bool Readable => false;
    public override bool Viewable => true;
}