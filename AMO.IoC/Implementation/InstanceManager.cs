using System;

namespace AMO.IoC.Implementation
{
    internal class InstanceManager : IInstanceManager
    {
        private readonly Func<Type, string, IResolveContext, object> _resolve;
        
        private object _instance;


        internal InstanceManager(Func<Type, string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            if (factory == null) { throw new ArgumentNullException("factory"); }
            
            switch (instanceManagement)
            {
                case InstanceManagement.Singleton: _resolve = (t, n, c) => singletonResolve(t, n, c, factory); break;
                case InstanceManagement.Transient: _resolve = (t, n, c) => transientResolve(t, n, c, factory); break;
                default:
                    throw new ArgumentException(string.Format("Instance management mode '{0}' is not supported.", instanceManagement));
            }
        }


        public object Resolve(Type type, string name, IResolveContext context)
        {
            return _resolve(type, name, context);
        }

        private object transientResolve(Type type, string name, IResolveContext context, Func<Type, string, IResolveContext, object> factory)
        {
            return factory(type, name, context);
        }

        private object singletonResolve(Type type, string name, IResolveContext context, Func<Type, string, IResolveContext, object> factory)
        {
            if (ReferenceEquals(_instance, null))
            {
                lock (this)
                {
                    if (ReferenceEquals(_instance, null))
                    {
                        _instance = factory(type, name, context);
                    }
                }
            }
            return _instance;
        }
    }
}
