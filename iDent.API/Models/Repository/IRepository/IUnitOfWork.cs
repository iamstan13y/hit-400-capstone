namespace iDent.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IIdentityRepository Identity { get; }
        IInvitationRepository Invitation { get; }
        void SaveChanges();
    }
}