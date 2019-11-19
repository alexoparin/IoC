namespace AMO.IoC.Test.HelperClasses
{
    class PropertyDependencyOwner : IDependencyOwner
    {
        [Inject]
        public ISimpleDependency Dependency { get; private set; }
    }
}
