using Autofac;
using PruebaTecnica.Core.Interfaces;
using PruebaTecnica.Core.Services;

namespace PruebaTecnica.Core;
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
