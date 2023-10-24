using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public class VideoAsset: Asset
{
    public Uri VideoUri { get; }
    
    public VideoAsset(string videoUrl) : base(EAssetType.Video)
    {
        VideoUri = new Uri(videoUrl);        
    }

    public override string GetContent()
    {
        return VideoUri.AbsoluteUri;
    }

    public override bool Readable => false;
    public override bool Viewable => true;
}