namespace RedisTestMemory.Caching
{
    public interface ICachingService
    {
        Task SetAsync(string key, string value);
        Task<string> FindById(string key);
    }
}
