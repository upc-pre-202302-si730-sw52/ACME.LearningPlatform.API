using ACME.LearningPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

public partial class Asset : IPublishable
{
    protected Asset(EAssetType type)
    {
        Type = type;
        Status = EPublishingStatus.ReadyToEdit;
        AssetIdentifier = new AcmeAssetIdentifier();
    }

    public int Id { get; }
    public AcmeAssetIdentifier AssetIdentifier { get; private set; }

    public EPublishingStatus Status { get; protected set; }

    public EAssetType Type { get; private set; }

    public virtual bool Readable => false;

    public virtual bool Viewable => false;

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

    public virtual object GetContent()
    {
        return string.Empty;
    }
}