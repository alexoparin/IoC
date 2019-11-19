namespace AMO.IoC.Test.HelperClasses
{
    class FieldDependencyOwner : IDependencyOwner
    {
        [Inject]
        public ISimpleDependency _fieldDependency;

        public ISimpleDependency Dependency { get { return _fieldDependency; } }
    }
}
