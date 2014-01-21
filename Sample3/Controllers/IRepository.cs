﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample3.Controllers
{
    public interface IRepository<TObject>
    {
        IQueryable<TObject> GetDocuments();
        TObject GetDocument(int id);
        IQueryable<TObject> GetDocuments(IEnumerable<string> ids);
        void AddDocument(TObject entity);
        void UpdateDocument(TObject entity);
        void DeleteDocument(TObject entity);
        void DeleteDocument(int id);
    }
}