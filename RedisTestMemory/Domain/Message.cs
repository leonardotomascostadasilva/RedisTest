namespace RedisTestMemory.Domain
{
    public class Message<T>
    {
        public string Key { get; set; }
        public T Data{ get; set; }
    }

    public class Data
    {
        public string Description { get; set; }
    }
}
