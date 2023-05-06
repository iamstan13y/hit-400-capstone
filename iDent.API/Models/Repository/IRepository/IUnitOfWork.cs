namespace iDent.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IIdentityRepository Identity { get; }
        void SaveChanges();
    }
}