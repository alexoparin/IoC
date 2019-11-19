using System;

namespace AMO.IoC
{
    public interface IResolveContext
    {
        IResolver         Resolver      { get; }
        IResolveOverrides Overrides     { get; }
    }
}
