namespace AMO.IoC.Test.HelperClasses
{
    class SimpleDependency : ISimpleDependency
    {
        static int depIdCount;

        public int DepId { get; private set; }

        public SimpleDependency()
        {
            DepId = ++depIdCount;
        }
    }
}
