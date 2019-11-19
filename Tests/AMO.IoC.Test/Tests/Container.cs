using System;
using AMO.IoC.Implementation;
using AMO.IoC.Test.HelperClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMO.IoC.Test
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTypeTypeNotSpecifiedThrowsTest()
        {
            var container = new Container();
           container.RegisterType(typeof(ISimpleData), null, null, InstanceManagement.Transient);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterInstanceInstanceNullThrowsTest()
        {
            var container = new Container();
            container.RegisterInstance(typeof(ISimpleData), null, null);
        }

        [TestMethod]
        public void ResolveUnregisteredTypeCreatesANewInstanceOfConcreteTypeTest()
        {
            var container = new Container();
            var obj = container.Resolve(typeof(SimpleData), null, null);

            Assert.IsInstanceOfType(obj, typeof(SimpleData));
        }

        [TestMethod]
        public void ResolveUnregisteredTypeResolvesItsDependenciesTest()
        {
            var container = new Container();
            var dep = new SimpleDependency();
            container.RegisterInstance(typeof(ISimpleDependency), dep, null);
            var depOwner = (ConstructorDependencyOwner)container.Resolve(typeof(ConstructorDependencyOwner), null, null);

            Assert.AreEqual(depOwner.Dependency, dep);
        }
    }
}
