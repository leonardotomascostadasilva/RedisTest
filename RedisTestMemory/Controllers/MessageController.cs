using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedisTestMemory.Caching;
using RedisTestMemory.Domain;

namespace RedisTestMemory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ICachingService _cache;

        public MessageController(ICachingService cache)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Message<Data> model)
        {
            await _cache.SetAsync(model.Key, JsonConvert.SerializeObject(model));
            return Created("", model);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetById(string key)
        {
            var model = await _cache.FindById(key);
  
            return Ok(model);
        }
    }
}