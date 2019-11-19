using System;

namespace AMO.IoC.Implementation
{
    internal interface IInstanceManager
    {
        object Resolve(Type type, string name, IResolveContext context);
    }
}
