using System;
using System.Collections.Generic;

namespace ChessWithTDD.Tests
{
    public class ServiceLocatorMock : IServiceLocator
    {
        private Dictionary<Type, object> _services;

        public ServiceLocatorMock(params object[] services)
        {
            _services = new Dictionary<Type, object>();
            foreach (var service in services)
            {
                _services.Add(service.GetType(), service);
            }
        }

        public T GetService<T>()
        {
            if (_services.ContainsKey(typeof(T)))
            {
                return (T) _services[typeof(T)];
            }
            else
            {
                throw new InvalidOperationException("Mock is not set up to return this service");
            }
        }
    }
}
