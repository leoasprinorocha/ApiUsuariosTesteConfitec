﻿using ApiUsuariosTesteConfitec_Domain.Interfaces.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuariosTesteConfitec_Data.DbSessionManagerConfig
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession _session;

        public UnitOfWork(DbSession session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();
    }
}
