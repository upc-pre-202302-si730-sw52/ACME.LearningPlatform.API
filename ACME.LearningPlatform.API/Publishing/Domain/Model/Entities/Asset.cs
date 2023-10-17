using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public abstract class Asset
{
    protected Asset(EAssetType type)
    {
        Type = type;
        Status = EAssetStatus.ReadyToEdit;
        AssetIdentifier = new AcmeAssetIdentifier();
    }

    public AcmeAssetIdentifier AssetIdentifier { get; private set; }
    
    public EAssetStatus Status {get; protected set;}
    
    public EAssetType Type {get; private set;}

    public abstract object GetContent();
    
    public abstract bool Readable { get; }
    
    public abstract bool Viewable { get; }

    public void SendToEdit()
    {
        Status = EAssetStatus.ReadyToEdit;
    }
    
    public void SendForApproval()
    {
        Status = EAssetStatus.ReadyToApproval;
    }

    public void Reject()
    {
        Status = EAssetStatus.ReadyToEdit;
    }

    public void ApproveAndLock()
    {
        Status = EAssetStatus.ApprovedAndLocked;
    }
    
    public void ReturnToEdit()
    {
        Status = EAssetStatus.ReadyToEdit;
    }
}