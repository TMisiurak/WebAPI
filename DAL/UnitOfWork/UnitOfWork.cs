using System;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationContext dbContext;
        IDbContextTransaction transaction;

        EmployeeRepository employeeRepository;
        PositionRepository positionRepository;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            dbContext = applicationContext;
        }

        public IEmployeeRepository Employees
        {
            get { return employeeRepository ?? (employeeRepository = new EmployeeRepository(dbContext)); }
        }

        public IPositionRepository Positions
        {
            get { return positionRepository ?? (positionRepository = new PositionRepository(dbContext)); }
        }

        public void BeginTransaction()
        {
            if (transaction == null)
                transaction = dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }
        }
    }
}
