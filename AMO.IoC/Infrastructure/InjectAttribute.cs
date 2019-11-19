using System;

namespace AMO.IoC
{
    [AttributeUsage(AttributeTargets.Class  | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class InjectAttribute : Attribute
    {
        public string Name { get; private set; }


        public InjectAttribute()
        {
        }

        public InjectAttribute(string name)
        {
            Name = name;
        }
    }
}
