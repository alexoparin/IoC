namespace AMO.IoC.Test.HelperClasses
{
    class AutoSelectedConstructor : IDependencyOwner
    {
        public ISimpleDependency Dependency { get; private set; }

        public AutoSelectedConstructor()
        {
        }

        public AutoSelectedConstructor(ISimpleDependency dep)
        {
            Dependency = dep;
        }
    }
}
