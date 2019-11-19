using AMO.IoC.Implementation;
using AMO.IoC.Test.HelperClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMO.IoC.Test
{
    [TestClass]
    public class RegisterFactoryTests
    {
        [TestMethod]
        public void RegisterFactorySingletonResolveTest()
        {
            var container = new Container();
            container.RegisterFactory(typeof(ISimpleData), null, (t, s, c) =>
            {
                return new SimpleData();
            }, InstanceManagement.Singleton);

            Assert.AreEqual(container.Resolve(typeof(ISimpleData), null, null), container.Resolve(typeof(ISimpleData), null, null));
        }

        [TestMethod]
        public void RegisterFactoryTransientResolveTest()
        {
            var container = new Container();
            container.RegisterFactory(typeof(ISimpleData), null, (t, s, c) =>
            {
                return new SimpleData();
            }, InstanceManagement.Transient);

            Assert.AreNotEqual(container.Resolve(typeof(ISimpleData), null, null), container.Resolve(typeof(ISimpleData), null, null));
        }
    }
}
