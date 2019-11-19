namespace AMO.IoC.Test.HelperClasses
{
    class SimpleData : ISimpleData
    {
        static int idCount;
        public int ObjId { get; private set; }

        public SimpleData()
        {
            ObjId = ++idCount;
        }
    }
}
