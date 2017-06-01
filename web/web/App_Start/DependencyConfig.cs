using Autofac;
using Autofac.Integration.Mvc;
using oclockvn.Repository;
using System.Web.Mvc;
using web.Models;

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

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}