using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Repository.Repositories;
using Insure.Partners.Hub.Service.Interfaces;
using Insure.Partners.Hub.Service.Services;
using System;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Insure.Partners.Hub
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {

            var connectionString = ConfigurationManager.AppSettings["ConnectionString"]; ;

            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType<IPolicyService, PolicyService>();

            container.RegisterType<IPartnerRepository, PartnerRepository>(connectionString);
            container.RegisterType<IPolicyRepository, PolicyRepository>(connectionString);
        }

        public static void RegisterComponents()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"]; ;

            var container = new UnityContainer();

            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType<IPolicyService, PolicyService>();

            container.RegisterType<IPartnerRepository, PartnerRepository>(connectionString);
            container.RegisterType<IPolicyRepository, PolicyRepository>(connectionString);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}