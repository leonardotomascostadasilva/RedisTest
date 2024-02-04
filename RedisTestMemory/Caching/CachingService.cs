using Microsoft.Extensions.Caching.Distributed;

namespace RedisTestMemory.Caching
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;
        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };
        }

        public async Task<string> FindById(string key) => await _cache.GetStringAsync(key);

        public async Task SetAsync(string key, string value) => await _cache.SetStringAsync(key, value);
    }
}
