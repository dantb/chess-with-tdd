using System;
using System.Collections.Generic;

namespace ChessWithTDD
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, object> _services;

        public ServiceLocator()
        {
            //add units test to ensure this initialises required services, and can be accessed via GetService
        }

        public T GetService<T>()
        {
            if (_services.ContainsKey(typeof(T)))
            {
                return (T) _services[typeof(T)];
            }
            else
            {
                //create custom exception for this
                throw new InvalidOperationException("Not a valid service");
            }
        }
    }
}
