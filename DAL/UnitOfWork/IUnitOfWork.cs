using DAL.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        }
}
