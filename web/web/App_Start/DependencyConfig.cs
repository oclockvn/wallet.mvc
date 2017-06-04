using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.Mvc;
using MediatR;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Web.Mvc;
using web.Models;
using web.Handlers;

namespace web
{
    public class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.Register(t => new UnitOfWork(new ApplicationDbContext())).As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            // register own type here
            //builder.RegisterGeneric(typeof(BaseBusiness<,,>)).As(typeof(IBaseBusiness<,,>));

            //builder.RegisterType<AreaBusiness>().As<IAreaBusiness>();
            //builder.RegisterType<ParkBusiness>().As<IParkBusiness>();
            //builder.RegisterType<StationBusiness>().As<IStationBusiness>();
            //builder.RegisterType<GroupBusiness>().As<IGroupBusiness>();
            //builder.RegisterType<DeviceBusiness>().As<IDeviceBusiness>();
            //builder.RegisterType<CustomerBusiness>().As<ICustomerBusiness>();
            //builder.RegisterType<UploadBusiness>().As<IUploadBusiness>();
            //builder.RegisterType<InventoryBusiness>().As<IInventoryBusiness>();
            //builder.RegisterType<OrderBusiness>().As<IOrderBusiness>();
            //builder.RegisterType<OrderDetailBusiness>().As<IOrderDetailBusiness>();
            //builder.RegisterType<AccountBusiness>().As<IAccountBusiness>();
            //builder.RegisterType<ReceiptBusiness>().As<IReceiptBusiness>();

            // enables contravariant Resolve() for interfaces with single contravariant ("in") arg
            builder.RegisterSource(new ContravariantRegistrationSource());

            // mediator itself
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            // request handlers
            builder
              .Register<SingleInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => { object o; return c.TryResolve(t, out o) ? o : null; };
              })
              .InstancePerLifetimeScope();

            // notification handlers
            builder
              .Register<MultiInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
              })
              .InstancePerLifetimeScope();

            // builder.RegisterAssemblyTypes(typeof(web.MvcApplication).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterType<ItemCreateHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<WalletIndexHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<WalletCreateHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<ItemDeleteHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<ItemDoneHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<ItemUndoneHandler>().AsImplementedInterfaces().InstancePerDependency();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}