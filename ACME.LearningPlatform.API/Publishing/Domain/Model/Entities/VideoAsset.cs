using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public class VideoAsset : Asset
{
    public VideoAsset() : base(EAssetType.Video)
    {
    }

    public VideoAsset(string videoUrl) : base(EAssetType.Video)
    {
        VideoUri = new Uri(videoUrl);
    }

    public Uri VideoUri { get; }

    public override bool Readable => false;
    public override bool Viewable => true;

    public override string GetContent()
    {
        return VideoUri.AbsoluteUri;
    }
}