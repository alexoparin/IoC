using System.Reflection;

namespace AMO.IoC.Implementation
{
    internal class DependencyInfo<T> where T : MemberInfo
    {
        internal readonly T                  Member;
        internal readonly RegistrationKey[] Dependencies;


        internal DependencyInfo(T member, RegistrationKey[] dependencies)
        {
            Member       = member;
            Dependencies = dependencies;
        }
    }
}
