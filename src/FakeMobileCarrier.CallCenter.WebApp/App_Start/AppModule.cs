using Autofac;
using FakeMobileCarrier.Model;

namespace FakeMobileCarrier.CallCenter.WebApp.App_Start
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<FakeMobileCarrierDbContext>()
                .AsSelf()
                .As<IFakeMobileCarrierDbContext>()
                .InstancePerRequest();
        }
    }
}