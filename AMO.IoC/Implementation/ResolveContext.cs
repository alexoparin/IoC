namespace AMO.IoC.Implementation
{
    internal class ResolveContext : IResolveContext
    {
        public IResolver         Resolver      { get; set; }
        public IResolveOverrides Overrides     { get; set; }
    }
}
