namespace LearningCenterPlatform.Publishing.Domain.Model.ValueObjects
{
    public interface IPublishable
    {
        void SendToEdit();
        void SendToApproval();
        void ApprovedAndLocked();
        void Reject();
        void ReturnToEdit();
    }
}
