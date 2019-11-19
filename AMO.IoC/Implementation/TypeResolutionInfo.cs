using System;
using System.Linq;
using System.Reflection;

namespace AMO.IoC.Implementation
{
    internal class TypeResolutionInfo
    {
        internal DependencyInfo<ConstructorInfo> Constructor { get; private set; }
        internal DependencyInfo<MethodInfo>[]    Methods     { get; private set; }
        internal DependencyInfo<PropertyInfo>[]  Properties  { get; private set; }
        internal DependencyInfo<FieldInfo>[]     Fields      { get; private set; }


        private TypeResolutionInfo()
        {
        }


        internal static TypeResolutionInfo Create(Type type, DependencyTypes dependencyTypes)
        {
            if (type == null) { throw new ArgumentNullException("type"); }

            return new TypeResolutionInfo()
            {
                Constructor = getConstructorDependencyInfo(type, dependencyTypes.HasFlag(DependencyTypes.Constructor)),
                Methods     = dependencyTypes.HasFlag(DependencyTypes.Method)   ? getMethodDependencyInfos(type)   : new DependencyInfo<MethodInfo>[0],
                Properties  = dependencyTypes.HasFlag(DependencyTypes.Property) ? getPropertyDependencyInfos(type) : new DependencyInfo<PropertyInfo>[0],
                Fields      = dependencyTypes.HasFlag(DependencyTypes.Field)    ? getFieldDependencyInfos(type)    : new DependencyInfo<FieldInfo>[0]
            };
        }

        private static DependencyInfo<ConstructorInfo> getConstructorDependencyInfo(Type type, bool withDependencies)
        {
            ConstructorInfo constructor = null;

            if (withDependencies)
            {
                ParameterInfo[] constructorParams = null;

                foreach (var c in type.GetConstructors())
                {
                    var cParameters = c.GetParameters();

                    if (constructor == null || constructorParams.Length < cParameters.Length)
                    {
                        constructor       = c;
                        constructorParams = cParameters;
                    }

                    if (c.GetCustomAttribute<InjectAttribute>() != null)
                    {
                        break;
                    }
                }
            }
            else
            {
                constructor = type.GetConstructor(Type.EmptyTypes);
            }
            
            if (constructor == null)
            {
                throw new InvalidOperationException(string.Format("Type {0} does not have public constructors", type.FullName));
            }
            return new DependencyInfo<ConstructorInfo>(constructor, getMethodArgsRegistrationInfos(constructor));
        }

        private static DependencyInfo<MethodInfo>[] getMethodDependencyInfos(Type type)
        {
            return (from mi in type.GetMethods()
                    where mi.GetCustomAttribute<InjectAttribute>() != null
                    select new DependencyInfo<MethodInfo>(mi, getMethodArgsRegistrationInfos(mi))).ToArray();
        }

        private static RegistrationKey[] getMethodArgsRegistrationInfos(MethodBase method)
        {
            return (from pi in method.GetParameters()
                    select new { pi, attr = pi.GetCustomAttribute<InjectAttribute>() } into e
                    select new RegistrationKey(e.pi.ParameterType, e.attr != null ? e.attr.Name : null)).ToArray();
        }

        private static DependencyInfo<PropertyInfo>[] getPropertyDependencyInfos(Type type)
        {
            return (from pi in type.GetProperties()
                    select new { pi, attr = pi .GetCustomAttribute<InjectAttribute>() } into e
                    where e.attr != null
                    select new DependencyInfo<PropertyInfo>(e.pi, new[] { new RegistrationKey(e.pi.PropertyType, e.attr.Name) })).ToArray();
        }

        private static DependencyInfo<FieldInfo>[] getFieldDependencyInfos(Type type)
        {
            return (from pi in type.GetFields()
                    select new { pi, attr = pi.GetCustomAttribute<InjectAttribute>() } into e
                    where e.attr != null
                    select new DependencyInfo<FieldInfo>(e.pi, new[] { new RegistrationKey(e.pi.FieldType, e.attr.Name) })).ToArray();
        }
    }
}
