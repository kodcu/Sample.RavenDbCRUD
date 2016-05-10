using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2
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
            docStore.Url = "http://localhost:55786/";
            docStore.DefaultDatabase = "Sample-2";

            docStore.Initialize();
            return docStore;
        });
    }

    
}
