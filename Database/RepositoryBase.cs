using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class RepositoryBase
    {
        public readonly AtmiraContext _db;
        private IDbContextTransaction _dbContextTransaction;

        public RepositoryBase(AtmiraContext db)
        {
            _db = db;
        }

        public void BeginTransaccion() {
            _dbContextTransaction = _db.Database.BeginTransaction();
        }

        public void CommitTransaccion()
        {
            _dbContextTransaction.Commit();
        }

        public void RollbackTransaccion()
        {
            _dbContextTransaction.Rollback();
        }
    }
}
