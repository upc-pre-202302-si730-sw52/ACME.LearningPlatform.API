using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public abstract class Asset : IPublishable
{
    protected Asset(EAssetType type)
    {
        Type = type;
        Status = EPublishingStatus.ReadyToEdit;
        AssetIdentifier = new AcmeAssetIdentifier();
    }

    public AcmeAssetIdentifier AssetIdentifier { get; private set; }
    
    public EPublishingStatus Status {get; protected set;}
    
    public EAssetType Type {get; private set;}

    public abstract object GetContent();
    
    public abstract bool Readable { get; }
    
    public abstract bool Viewable { get; }

    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }
    
    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApproval;
    }

    public void Reject()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }
    
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }
}