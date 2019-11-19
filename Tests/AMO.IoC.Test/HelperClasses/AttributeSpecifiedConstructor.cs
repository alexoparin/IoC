namespace AMO.IoC.Test.HelperClasses
{
    class AttributeSpecifiedConstructor : IDependencyOwner
    {
        public ISimpleDependency Dependency { get; private set; }

        [Inject]
        public AttributeSpecifiedConstructor()
        {
        }

        public AttributeSpecifiedConstructor(ISimpleDependency dep)
        {
            Dependency = dep;
        }
    }
}
