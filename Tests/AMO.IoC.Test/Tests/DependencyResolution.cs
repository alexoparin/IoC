using AMO.IoC.Implementation;
using AMO.IoC.Test.HelperClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMO.IoC.Test
{
    [TestClass]
    public class DependencyResolutionTests
    {
        [TestMethod]
        public void ConstructorDependencyResolveTest()
        {
            var container = new Container();
            container.RegisterType(typeof(IDependencyOwner), typeof(DependencyOwner), null, InstanceManagement.Transient);
            container.RegisterType(typeof(ISimpleDependency), typeof(SimpleDependency), null, InstanceManagement.Transient);

            var depOwner = (IDependencyOwner)container.Resolve(typeof(IDependencyOwner), null, null);
            Assert.IsNotNull(depOwner.Dependency);
        }

        [TestMethod]
        public void ConstructorAutoSelectionWithMaxArgsTest()
        {
            var container = new Container();
            container.RegisterType(typeof(IDependencyOwner), typeof(AutoSelectedConstructor), null, InstanceManagement.Transient);
            container.RegisterType(typeof(ISimpleDependency), typeof(SimpleDependency), null, InstanceManagement.Transient);

            var depOwner = (IDependencyOwner)container.Resolve(typeof(IDependencyOwner), null, null);
            Assert.IsNotNull(depOwner.Dependency);
        }

        [TestMethod]
        public void RegisterTypeConstructorSpecifiedByInjectAttributeTest()
        {
            var container = new Container();
            container.RegisterType(typeof(IDependencyOwner), typeof(AttributeSpecifiedConstructor), null, InstanceManagement.Transient);
            container.RegisterType(typeof(ISimpleDependency), typeof(SimpleDependency), null, InstanceManagement.Transient);

            var depOwner = (IDependencyOwner)container.Resolve(typeof(IDependencyOwner), null, null);
            Assert.IsNull(depOwner.Dependency);
        }

        [TestMethod]
        public void MethodDependencyInjectionTest()
        {
            var container = new Container();
            container.RegisterType(typeof(IDependencyOwner), typeof(MethodDependencyOwner), null, InstanceManagement.Transient);
            container.RegisterType(typeof(ISimpleDependency), typeof(SimpleDependency), null, InstanceManagement.Transient);

            var depOwner = (IDependencyOwner)container.Resolve(typeof(IDependencyOwner), null, null);
            Assert.IsNotNull(depOwner.Dependency);
        }

        [TestMethod]
        public void RegisterTypeMarkedPropertyGetsInjectedTest()
        {
            var container = new Container();
            container.RegisterType(typeof(IDependencyOwner), typeof(PropertyDependencyOwner), null, InstanceManagement.Transient);
            container.RegisterType(typeof(ISimpleDependency), typeof(SimpleDependency), null, InstanceManagement.Transient);

            var depOwner = (IDependencyOwner)container.Resolve(typeof(IDependencyOwner), null, null);
            Assert.IsNotNull(depOwner.Dependency);
        }

        [TestMethod]
        public void RegisterTypeMarkedFieledGetsInjectedTest()
        {
            var container = new Container();
            container.RegisterType(typeof(IDependencyOwner), typeof(FieldDependencyOwner), null, InstanceManagement.Transient);
            container.RegisterType(typeof(ISimpleDependency), typeof(SimpleDependency), null, InstanceManagement.Transient);

            var depOwner = (IDependencyOwner)container.Resolve(typeof(IDependencyOwner), null, null);
            Assert.IsNotNull(depOwner.Dependency);
        }
    }
}
