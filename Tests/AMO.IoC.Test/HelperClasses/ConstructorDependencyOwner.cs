namespace AMO.IoC.Test.HelperClasses
{
    class ConstructorDependencyOwner : IDependencyOwner
    {
        public ISimpleDependency Dependency { get; private set; }


        public ConstructorDependencyOwner(ISimpleDependency dep)
        {
            Dependency = dep;
        }
    }
}
