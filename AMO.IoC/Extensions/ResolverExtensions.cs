using System;

namespace AMO.IoC
{
    public static class ResolverExtensions
    {
        public static object Resolve(this IResolver resolver, Type type)
        {
            return resolver.Resolve(type, null, null);
        }

        public static object Resolve(this IResolver resolver, Type type, string name)
        {
            return resolver.Resolve(type, name, null);
        }

        public static T Resolve<T>(this IResolver resolver)
        {
            return (T)resolver.Resolve(typeof(T), null, null);
        }

        public static T Resolve<T>(this IResolver resolver, string name)
        {
            return (T)resolver.Resolve(typeof(T), name, null);
        }

        public static T Resolve<T>(this IResolver resolver, string name, IResolveOverrides resolveOverrides)
        {
            return (T)resolver.Resolve(typeof(T), name, resolveOverrides);
        }
    }
}
