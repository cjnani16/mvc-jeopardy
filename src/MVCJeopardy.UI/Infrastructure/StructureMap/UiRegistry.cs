using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Extensions;
using StructureMap.Configuration.DSL;

namespace MVCJeopardy.UI.Infrastructure.StructureMap
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            var store = new EmbeddableDocumentStore
            {
                RunInMemory = true,
            };
            store.Initialize();

            For<IDocumentStore>().Use(store);
            For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(ctx =>
            {
                return ctx.GetInstance<IDocumentStore>().OpenSession();
            });
        }
    }
}