using DAL.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IPositionRepository Positions { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        }
}
