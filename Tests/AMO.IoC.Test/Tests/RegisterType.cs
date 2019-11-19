using System;
using AMO.IoC.Implementation;
using AMO.IoC.Test.HelperClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMO.IoC.Test
{
    [TestClass]
    public class RegisterTypeTests
    {
        [TestMethod]
        public void RegisterTypeResolve()
        {
            var container = new Container();
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), null, InstanceManagement.Transient);

            var obj = container.Resolve(typeof(ISimpleData), null, null);
            Assert.IsInstanceOfType(obj, typeof(SimpleData));
        }

        [TestMethod]
        public void RegisterTypeTransientResolve()
        {
            var container = new Container();
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), null, InstanceManagement.Transient);

            var obj1 = container.Resolve(typeof(ISimpleData), null, null);
            var obj2 = container.Resolve(typeof(ISimpleData), null, null);
            Assert.AreNotEqual(obj1, obj2);
        }

        [TestMethod]
        public void RegisterTypeSingletonResolve()
        {
            var container = new Container();
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), null, InstanceManagement.Singleton);

            var obj1 = container.Resolve(typeof(ISimpleData), null, null);
            var obj2 = container.Resolve(typeof(ISimpleData), null, null);
            Assert.IsNotNull(obj1);
            Assert.AreEqual(obj1, obj2);
        }

        [TestMethod]
        public void RegisterTypeNamedTransientResolve()
        {
            var container = new Container();
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), "obj1", InstanceManagement.Transient);

            var obj1 = container.Resolve(typeof(ISimpleData), "obj1", null);
            var obj2 = container.Resolve(typeof(ISimpleData), "obj1", null);
            Assert.AreNotEqual(obj1, obj2);
        }

        [TestMethod]
        public void RegisterTypeNamedSingletonResolve()
        {
            var container = new Container();
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), "obj1", InstanceManagement.Singleton);

            var obj1 = container.Resolve(typeof(ISimpleData), "obj1", null);
            var obj2 = container.Resolve(typeof(ISimpleData), "obj1", null);
            Assert.IsNotNull(obj1);
            Assert.AreEqual(obj1, obj2);
        }

        [TestMethod]
        public void RegisterTypeResolveErrorIfNameNotRegisterer()
        {
            var container = new Container();
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), "obj1", InstanceManagement.Singleton);

            Assert.ThrowsException<InvalidOperationException>(() => container.Resolve(typeof(ISimpleData), null, null));
            Assert.ThrowsException<InvalidOperationException>(() => container.Resolve(typeof(ISimpleData), "obj2", null));
        }

        [TestMethod]
        public void RegisterTypeNamedRegistrationAreDifferentRegistrations()
        {
            var container = new Container();
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), null, InstanceManagement.Singleton);
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), "obj1", InstanceManagement.Singleton);
            container.RegisterType(typeof(ISimpleData), typeof(SimpleData), "obj2", InstanceManagement.Singleton);

            Assert.AreNotEqual(
                container.Resolve(typeof(ISimpleData), null, null),
                container.Resolve(typeof(ISimpleData), "obj1", null));

            Assert.AreNotEqual(
                container.Resolve(typeof(ISimpleData), "obj1", null),
                container.Resolve(typeof(ISimpleData), "obj2", null));
        }

        [TestMethod]
        public void RegisterTypeWithoutBaseTypeTest()
        {
            var container = new Container();
            container.RegisterType(null, typeof(PropertyDependencyOwner), null, InstanceManagement.Transient);
            container.RegisterType(typeof(ISimpleDependency), typeof(SimpleDependency), null, InstanceManagement.Transient);

            var depOwner = (IDependencyOwner)container.Resolve(typeof(PropertyDependencyOwner), null, null);
            Assert.IsInstanceOfType(depOwner, typeof(PropertyDependencyOwner));
            Assert.IsNotNull(depOwner.Dependency);
        }
    }
}
