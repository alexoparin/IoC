using System;

namespace AMO.IoC.Implementation
{
    [Flags]
    internal enum DependencyTypes
    {
        Constructor = 0x01,
        Method      = 0x02,
        Property    = 0x04,
        Field       = 0x08,
        All         = Constructor | Method | Property | Field,
    }
}
