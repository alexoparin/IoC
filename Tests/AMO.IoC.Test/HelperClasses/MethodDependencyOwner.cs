namespace AMO.IoC.Test.HelperClasses
{
    class MethodDependencyOwner : IDependencyOwner
    {
        public ISimpleDependency Dependency { get; private set; }

        [Inject]
        public void DependencyResolveMethod(ISimpleDependency dep)
        {
            Dependency = dep;
        }
    }
}
