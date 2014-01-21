using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2
{
    public class ForaDataOperation
       : ForaDocumentStore, IDisposable
    {
        private IDocumentSession session;
        public IDocumentSession Session
        {
            get
            {
                if (session == null)
                {
                    session = Store.OpenSession();
                }
                return session;
            }
        }

        public IQueryable<T> GetDocuments<T>()
        {
            return Session.Query<T>();
        }

        public T GetDocument<T>(int id)
        {
            return Session.Load<T>(id);
        }

        public IQueryable<T> GetDocuments<T>(IEnumerable<string> ids)
        {
            return Session.Load<T>(ids).AsQueryable();
        }

        public void AddDocument<T>(T entity)
        {
            Session.Store(entity);
            SaveChanges();
        }

        public void UpdateDocument<T>(T entity)
        {
            Session.Store(entity);
            SaveChanges();
        }

        public void DeleteDocument<T>(T entity)
        {
            Session.Delete<T>(entity);
            SaveChanges();
        }

        public void DeleteDocument<T>(int id)
        {
            T entity = GetDocument<T>(id);
            Session.Delete<T>(entity);
            SaveChanges();
        }

        public void Dispose()
        {
            Session.SaveChanges();
            Session.Dispose();
        }

        public void SaveChanges()
        {
            Session.SaveChanges();
        }
    }
}
