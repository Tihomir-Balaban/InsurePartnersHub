using Insure.Partners.Hub.Repository.Interfaces;
using Insure.Partners.Hub.Repository.Repositories;
using Insure.Partners.Hub.Service.Interfaces;
using Insure.Partners.Hub.Service.Services;
using System;
using Unity;

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
            container.RegisterType<IPartnerRepository, PartnerRepository>();
            container.RegisterType<IPolicyRepository, PolicyRepository>();
            
            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType<IPolicyService, PolicyService>();
        }
    }
}