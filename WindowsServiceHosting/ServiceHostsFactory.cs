﻿namespace WindowsServiceHosting
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using WCFServices.HostConfigurationFactory;

    internal static class ServiceHostsFactory
    {
        private static readonly Lazy<IEnumerable<ServiceHost>> HostsList = new Lazy<IEnumerable<ServiceHost>>(GetHosts);

        public static IEnumerable<ServiceHost> Hosts
        {
            get
            {
                return HostsList.Value;
            }
        }

        private static IEnumerable<ServiceHost> GetHosts()
        {
            return new List<ServiceHost>
                       {
                           GetOrdersServiceHost(),
                           GetCategoriesServiceHost()
                       };
        }

        private static ServiceHost GetOrdersServiceHost()
        {
            var ordersServiceBaseAddress = new Uri("http://epruizhw0228:8733/Design_Time_Addresses/NorthwindWCFServices/OrdersService/");

            return new OrdersServiceHostConfigurationBuilder(ordersServiceBaseAddress)
                             .AddNetTcpEndpoint("net.tcp://epruizhw0228:809/NorthwindWCFServices/OrdersService")
                             .Configure();
        }

        private static ServiceHost GetCategoriesServiceHost()
        {
            var categoriesServiceBaseAddress = new Uri("http://epruizhw0228:8733/Design_Time_Addresses/NorthwindWCFServices/CategoriesService/");

            return new CategoriesServiceHostConfigurationBuilder(categoriesServiceBaseAddress)
                        .AddNetTcpEndpoint("net.tcp://epruizhw0228:810/NorthwindWCFServices/CategoriesService")
                        .Configure();
        }
    }
}