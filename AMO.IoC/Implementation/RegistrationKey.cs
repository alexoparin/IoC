using System;
using System.Collections.Generic;

namespace AMO.IoC.Implementation
{
    internal struct RegistrationKey : IEquatable<RegistrationKey>
    {
        internal Type   Type { get; private set; }
        internal string Name { get; private set; }


        internal RegistrationKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }


        public override int GetHashCode()
        {
            var hashCode = -1979447941;
            hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return
                !ReferenceEquals(obj, null) &&
                obj is RegistrationKey &&
                EqualityComparer<RegistrationKey>.Default.Equals(this, (RegistrationKey)obj);
        }

        public bool Equals(RegistrationKey other)
        {
            return
                Type == other.Type &&
                Name == other.Name;
        }

        public static bool operator ==(RegistrationKey left, RegistrationKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RegistrationKey left, RegistrationKey right)
        {
            return !(left == right);
        }
    }
}
