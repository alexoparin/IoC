using System;

namespace AMO.IoC
{
    public static class RegistryExtensions
    {
        private const InstanceManagement DEFAULT_INSTANCE_MANAGEMENT = InstanceManagement.Transient;

        #region RegisterType

        public static IRegistry RegisterType(this IRegistry registry, Type type)
        {
            return registry.RegisterType(null, type, null, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterType(this IRegistry registry, Type type, string name)
        {
            return registry.RegisterType(null, type, name, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterType(this IRegistry registry, Type baseType, Type type)
        {
            return registry.RegisterType(baseType, type, null, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterType(this IRegistry registry, Type baseType, Type type, string name)
        {
            return registry.RegisterType(baseType, type, name, DEFAULT_INSTANCE_MANAGEMENT);
        }
        
        #endregion

        #region RegisterType Generic Overloads

        public static IRegistry RegisterType<T>(this IRegistry registry)
        {
            return registry.RegisterType(null, typeof(T), null, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterType<T>(this IRegistry registry, string name)
        {
            return registry.RegisterType(null, typeof(T), name, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterType<TBase, T>(this IRegistry registry) where T : TBase
        {
            return registry.RegisterType(typeof(TBase), typeof(T), null, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterType<TBase, T>(this IRegistry registry, string name)
        {
            return registry.RegisterType(typeof(TBase), typeof(T), name, DEFAULT_INSTANCE_MANAGEMENT);
        }

        #endregion

        #region RegisterSingleton

        public static IRegistry RegisterSingleton(this IRegistry registry, Type type)
        {
            return registry.RegisterType(null, type, null, InstanceManagement.Singleton);
        }

        public static IRegistry RegisterSingleton(this IRegistry registry, Type type, string name)
        {
            return registry.RegisterType(null, type, name, InstanceManagement.Singleton);
        }

        public static IRegistry RegisterSingleton(this IRegistry registry, Type baseType, Type type)
        {
            return registry.RegisterType(baseType, type, null, InstanceManagement.Singleton);
        }

        public static IRegistry RegisterSingleton(this IRegistry registry, Type baseType, Type type, string name)
        {
            return registry.RegisterType(baseType, type, name, InstanceManagement.Singleton);
        }

        #endregion

        #region RegisterSingleton Generic Overloads

        public static IRegistry RegisterSingleton<T>(this IRegistry registry)
        {
            return registry.RegisterType(null, typeof(T), null, InstanceManagement.Singleton);
        }

        public static IRegistry RegisterSingleton<T>(this IRegistry registry, string name)
        {
            return registry.RegisterType(null, typeof(T), name, InstanceManagement.Singleton);
        }

        public static IRegistry RegisterSingleton<TBase, T>(this IRegistry registry) where T : TBase
        {
            return registry.RegisterType(typeof(TBase), typeof(T), null, InstanceManagement.Singleton);
        }

        public static IRegistry RegisterSingleton<TBase, T>(this IRegistry registry, string name)
        {
            return registry.RegisterType(typeof(TBase), typeof(T), name, InstanceManagement.Singleton);
        }

        #endregion

        #region RegisterInstance

        public static IRegistry RegisterInstance(this IRegistry registry, object instance)
        {
            return registry.RegisterInstance(null, instance, null);
        }

        public static IRegistry RegisterInstance(this IRegistry registry, object instance, string name)
        {
            return registry.RegisterInstance(null, instance, name);
        }

        public static IRegistry RegisterInstance(this IRegistry registry, Type baseType, object instance)
        {
            return registry.RegisterInstance(baseType, instance, null);
        }

        #endregion

        #region RegisterFactory

        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, Func<IResolveContext, object> factory)
        {
            return registry.RegisterFactory(baseType, null, (t, n, c) => factory(c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, Func<string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(baseType, null, (t, n, c) => factory(n, c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, Func<Type, string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(baseType, null, factory, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, Func<IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(baseType, null, (t, n, c) => factory(c), instanceManagement);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, Func<string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(baseType, null, (t, n, c) => factory(n, c), instanceManagement);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, Func<Type, string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(baseType, null, factory, instanceManagement);
        }


        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, string name, Func<IResolveContext, object> factory)
        {
            return registry.RegisterFactory(baseType, name, (t, n, c) => factory(c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, string name, Func<string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(baseType, name, (t, n, c) => factory(n, c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, string name, Func<Type, string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(baseType, name, factory, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, string name, Func<IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(baseType, name, (t, n, c) => factory(c), instanceManagement);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, string name, Func<string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(baseType, name, (t, n, c) => factory(n, c), instanceManagement);
        }
        public static IRegistry RegisterFactory(this IRegistry registry, Type baseType, string name, Func<Type, string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(baseType, name, factory, instanceManagement);
        }

        #endregion

        #region RegisterFactory Generic Overloads

        public static IRegistry RegisterFactory<T>(this IRegistry registry, Func<IResolveContext, object> factory)
        {
            return registry.RegisterFactory(typeof(T), null, (t, n, c) => factory(c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, Func<string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(typeof(T), null, (t, n, c) => factory(n, c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, Func<Type, string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(typeof(T), null, factory, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterFactory<T>(this IRegistry registry, Func<IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(typeof(T), null, (t, n, c) => factory(c), instanceManagement);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, Func<string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(typeof(T), null, (t, n, c) => factory(n, c), instanceManagement);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, Func<Type, string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(typeof(T), null, factory, instanceManagement);
        }

        public static IRegistry RegisterFactory<T>(this IRegistry registry, string name, Func<IResolveContext, object> factory)
        {
            return registry.RegisterFactory(typeof(T), name, (t, n, c) => factory(c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, string name, Func<string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(typeof(T), name, (t, n, c) => factory(n, c), DEFAULT_INSTANCE_MANAGEMENT);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, string name, Func<Type, string, IResolveContext, object> factory)
        {
            return registry.RegisterFactory(typeof(T), name, factory, DEFAULT_INSTANCE_MANAGEMENT);
        }

        public static IRegistry RegisterFactory<T>(this IRegistry registry, string name, Func<IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(typeof(T), name, (t, n, c) => factory(c), instanceManagement);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, string name, Func<string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(typeof(T), name, (t, n, c) => factory(n, c), instanceManagement);
        }
        public static IRegistry RegisterFactory<T>(this IRegistry registry, string name, Func<Type, string, IResolveContext, object> factory, InstanceManagement instanceManagement)
        {
            return registry.RegisterFactory(typeof(T), name, factory, instanceManagement);
        }

        #endregion
    }
}
