﻿using System;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Hangfire.FluentNHibernateStorage
{
    public class StatelessSessionWrapper : IDisposable
    {
        private readonly IStatelessSession _session;

        public StatelessSessionWrapper(IStatelessSession session, FluentNHibernateJobStorage storage)
        {
            _session = session;
            Storage = storage;
        }

        public FluentNHibernateJobStorage Storage { get; }


        public void Dispose()
        {
            _session?.Dispose();
        }

        public void DeleteAll<T>()
        {
            _session.Query<T>().Delete();
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }

        public IQuery CreateQuery(string queryString)
        {
            return _session.CreateQuery(queryString);
        }

        public void Insert(object entity)
        {
            _session.Insert(entity);
        }

        public void Update(object entity)
        {
            _session.Update(entity);
        }
    }
}