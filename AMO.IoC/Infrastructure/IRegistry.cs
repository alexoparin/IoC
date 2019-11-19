using System;

namespace AMO.IoC
{
    public interface IRegistry
    {
        IRegistry RegisterFactory(Type baseType, string name, Func<Type, string, IResolveContext, object> factory, InstanceManagement instanceManagement);
        IRegistry RegisterInstance(Type baseType, object instance, string name);
        IRegistry RegisterType(Type baseType, Type concreteType, string name, InstanceManagement instanceManagement);
    }
}
