using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Service
    {

        public ServiceType Servicetype { get; set; }
    }

    public enum ServiceType
    {
        LoggerType
    }

    public class ServiceCollection
    {
        private List<Service> _services;

        public ServiceCollection()
        {
            _services = new List<Service>();
        }

        public void AddService(Service service)
        {
            _services.Add(service);
        }
        public List<Service> GetServices()
        {
            return _services;
        }
    }


    public class ServiceProvider
    {
        ServiceCollection _serviceCollection;
        public ServiceProvider(ServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public Service GetService(string name)
        {
            return _serviceCollection.GetServices().Find(s => s.Servicetype.Equals(ServiceType.LoggerType));
        }
    }

    

    
}
