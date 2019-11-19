using System;

namespace AMO.IoC
{
    public interface IResolver
    {
        object Resolve(Type type, string name, IResolveOverrides overrides);
    }
}
