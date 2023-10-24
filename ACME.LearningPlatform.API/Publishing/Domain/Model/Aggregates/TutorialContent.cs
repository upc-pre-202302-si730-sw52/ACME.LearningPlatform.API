using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial: Asset
{
    public Tutorial():base(EAssetType.Tutorial)
    {
        Title = string.Empty;
        Summary = string.Empty;
        Status = EPublishingStatus.Draft;
        Assets = new List<Asset>();
    }
    
    public AcmeAssetIdentifier TutorialIdentifier => AssetIdentifier;
    
    private ICollection<Asset> Assets { get; }
    
    public override List<ContentItem> GetContent()
    {
        var content = new List<ContentItem>();
        if (Assets.Any()) content.AddRange(
            Assets.Select(asset => 
                new ContentItem(asset.Type.ToString(), asset.GetContent() 
                    as string ?? string.Empty)));
        return content;
    }

    private bool HasReadableAssets
    {
        get { return Assets.Any(asset => asset.Readable); }
    }

    private bool HasViewableAssets
    {
        get { return Assets.Any(asset => asset.Viewable); }
    }
        
    public override bool Readable => HasReadableAssets;
    public override bool Viewable => HasViewableAssets;

    public void AddImage(string imageUrl)
    {
        if (ExistsImageByUrl(imageUrl)) return;
        Assets.Add(new ImageAsset(imageUrl));
    }

    private bool ExistsImageByUrl(string imageUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Image && (string)asset.GetContent() == imageUrl);
    }

    private bool ExistsVideoByUrl(string videoUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Video && (string)asset.GetContent() == videoUrl);
    }
    
    public void AddVideo(string videoUrl)
    {
        if (ExistsVideoByUrl(videoUrl)) return;
        Assets.Add(new VideoAsset(videoUrl));
    }

    private bool ExistsReadableContent(string content)
    {
        return Assets.Any(
            asset => asset.Type == EAssetType.ReadableContentItem && (string)asset.GetContent() == content);
    }
    
    public void AddReadableContent(string content)
    {
        if (ExistsReadableContent(content)) return;
        Assets.Add(new ReadableContentAsset(content));
    }

    public void RemoveAsset(AcmeAssetIdentifier identifier)
    {
        var asset = Assets.FirstOrDefault(a => a.AssetIdentifier == identifier);
        if (asset != null) Assets.Remove(asset);
    }

    public void ClearAssets()
    {
        Assets.Clear();
    }
    
}