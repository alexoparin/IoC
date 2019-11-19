using AMO.IoC.Implementation;
using AMO.IoC.Test.HelperClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMO.IoC.Test
{
    [TestClass]
    public class RegisterInstanceTests
    {
        [TestMethod]
        public void RegisterInstanceResolveTest()
        {
            var container     = new Container();
            var simpleDataObj = new SimpleData();
            container.RegisterInstance(typeof(ISimpleData), simpleDataObj, null);

            Assert.AreEqual(simpleDataObj, container.Resolve(typeof(ISimpleData), null, null));
        }

        [TestMethod]
        public void RegisterInstanceResolvesToTheSameInstanceTest()
        {
            var container = new Container();
            var simpleDataObj = new SimpleData();
            container.RegisterInstance(typeof(ISimpleData), simpleDataObj, null);

            Assert.AreEqual(container.Resolve(typeof(ISimpleData), null, null), container.Resolve(typeof(ISimpleData), null, null));
        }

        [TestMethod]
        public void RegisterBaseTypeNotSpecifiedTest()
        {
            var container = new Container();
            container.RegisterInstance(null, new SimpleData(), null);

            Assert.IsInstanceOfType(container.Resolve(typeof(SimpleData), null, null), typeof(SimpleData));
        }

        [TestMethod]
        public void RegisterNamedInstanceTest()
        {
            var container = new Container();
            container.RegisterInstance(typeof(ISimpleData), new SimpleData(), null);
            container.RegisterInstance(typeof(ISimpleData), new SimpleData(), "obj1");
            container.RegisterInstance(typeof(ISimpleData), new SimpleData(), "obj2");

            var res1 = container.Resolve(typeof(ISimpleData), null, null);
            var res2 = container.Resolve(typeof(ISimpleData), "obj1", null);
            var res3 = container.Resolve(typeof(ISimpleData), "obj2", null);

            Assert.IsInstanceOfType(res1, typeof(SimpleData));
            Assert.IsInstanceOfType(res2, typeof(SimpleData));
            Assert.IsInstanceOfType(res3, typeof(SimpleData));
            Assert.AreNotEqual(res1, res2);
            Assert.AreNotEqual(res2, res3);
            Assert.AreNotEqual(res3, res1);
        }
    }
}
