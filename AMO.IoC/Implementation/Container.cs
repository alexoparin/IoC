using System;
using System.Collections.Generic;
using System.Linq;

namespace AMO.IoC.Implementation
{
    internal class Container : IContainer
    {
        private Dictionary<RegistrationKey, IInstanceManager> _registry;


        internal Container()
        {
            _registry = new Dictionary<RegistrationKey, IInstanceManager>();
        }


        public IRegistry RegisterFactory(Type baseType, string name, Func<Type, string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            if (baseType == null) { throw new ArgumentNullException("baseType"); }

            _registry[new RegistrationKey(baseType, name)] = new InstanceManager(factory, instanceManagement);
            return this;
        }

        public IRegistry RegisterInstance(Type baseType, object instance, string name)
        {
            if (instance == null) { throw new ArgumentNullException("instance"); }

            baseType = baseType ?? instance.GetType();
            _registry[new RegistrationKey(baseType, name)] = new InstanceManager((t,s,c) => instance, InstanceManagement.Singleton);
            return this;
        }

        public IRegistry RegisterType(Type baseType, Type concreteType, string name, InstanceManagement instanceManagement)
        {
            if (concreteType == null) { throw new ArgumentNullException("concreteType"); }

            baseType = baseType ?? concreteType;
            _registry[new RegistrationKey(baseType, name)] = new InstanceManager(createTypeFactory(concreteType), instanceManagement);
            return this;
        }


        public object Resolve(Type type, string name, IResolveOverrides overrides)
        {
            if (type == null) { throw new ArgumentNullException("type"); }
            
            return resolve(type, name, new ResolveContext()
            {
                Resolver      = this,
                Overrides     = overrides
            });
        }

        private object resolve(Type type, string name, IResolveContext context)
        {
            IInstanceManager instanceManager;
            if (_registry.TryGetValue(new RegistrationKey(type, name), out instanceManager))
            {
                return instanceManager.Resolve(type, name, context);
            }
            else if (type.IsValueType) // Попытаемся создать объект
            {
                return Activator.CreateInstance(type);
            }
            else if (type.IsClass && !type.IsAbstract && !type.IsInterface && (!type.IsGenericType || type.IsConstructedGenericType))
            {
                return createTypeFactory(type)(type, name, context);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Type {0} not registered under name \"{1}\"", type, name));
            }
        }


        private Func<Type, string, IResolveContext, object> createTypeFactory(Type type)
        {
            var resolutionInfo = TypeResolutionInfo.Create(type, DependencyTypes.All);
            return (t,s,c) => createObjectOfType(resolutionInfo, c);
        }

        private object createObjectOfType(TypeResolutionInfo ri, IResolveContext c)
        {
            var ctorArgs = ri.Constructor.Dependencies.Select(d => resolve(d.Type, d.Name, c)).ToArray();
            var obj      = ri.Constructor.Member.Invoke(ctorArgs);
            
            foreach (var f in ri.Fields)
            {
                f.Member.SetValue(obj, resolve(f.Dependencies[0].Type, f.Dependencies[0].Name, c));
            }
            foreach (var p in ri.Properties)
            {
                p.Member.SetValue(obj, resolve(p.Dependencies[0].Type, p.Dependencies[0].Name, c));
            }
            foreach (var m in ri.Methods)
            {
                var methodArgs = m.Dependencies.Select(d => resolve(d.Type, d.Name, c)).ToArray();
                m.Member.Invoke(obj, methodArgs);
            }
            return obj;
        }
    }
}
