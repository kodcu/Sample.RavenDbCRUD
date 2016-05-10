using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample3.Controllers
{
    public class ForaDocumentStore
    {
        public IDocumentStore Store
        {
            get { return LazyDocStore.Value; }
        }

        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            var docStore = new DocumentStore();
            docStore.Url = EnvironmentConstants.DbServerUrl;
            docStore.DefaultDatabase = EnvironmentConstants.DbName;

            docStore.Initialize();
            return docStore;
        });
    }

    public static class EnvironmentConstants
    {
        public const string DbServerUrl = "http://localhost:55786/";
        public const string DbName = "Sample-3";
    }

}