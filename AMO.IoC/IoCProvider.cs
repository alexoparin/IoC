using AMO.IoC.Implementation;

namespace AMO.IoC
{
    public static class IoCProvider
    {
        private static object     _lock = new object();
        private static IContainer _instance;

        /// <summary>
        /// Provides an <see cref="IContainer"/> singleton.
        /// </summary>
        public static IContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = CreateContainer();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Container factory.
        /// </summary>
        /// <returns>New <see cref="IContainer"/> instance.</returns>
        public static IContainer CreateContainer()
        {
            var container = new Container();

            container.RegisterInstance(typeof(IContainer), container, null);
            container.RegisterInstance(typeof(IRegistry),  container, null);
            container.RegisterInstance(typeof(IResolver),  container, null);

            return container;
        }
    }
}
