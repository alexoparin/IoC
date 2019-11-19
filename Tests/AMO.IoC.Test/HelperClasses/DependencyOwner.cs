namespace AMO.IoC.Test.HelperClasses
{
    class DependencyOwner : IDependencyOwner
    {
        public ISimpleDependency Dependency { get; private set; }

        public DependencyOwner(ISimpleDependency dep)
        {
            Dependency = dep;
        }
    }
}
