using Autofac;
using InventoryManagement.Web.Contexts;
using InventoryManagement.Web.Repositories;
using InventoryManagement.Web.Services;

namespace InventoryManagement.Web
{
    public class InventoryModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InventoryModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<InventoryDbContext>().As<IInventoryDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ItemService>().As<IItemService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ItemRepository>().As<IItemRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
