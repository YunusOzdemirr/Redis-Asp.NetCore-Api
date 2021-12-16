using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using CacheTest.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CacheTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CachesController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        public string CachedTimeUTC { get; set; }
        public CachesController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet("getkey")]
        public async Task<string> Get(string cacheKey)
        {
            var existingTime = await _distributedCache.GetStringAsync(cacheKey).ConfigureAwait(false);
                
            if (!string.IsNullOrEmpty(existingTime))
            {
                return "Fetched from cache: " + existingTime;
            }
            else
            {
                return "No item exists";
            }
        }

       
        

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                var keys = redis.GetServer("127.0.0.1", 6379).Keys();

                string[] keysArr = keys.Select(key => (string)key).ToArray();
                List<object> list = new List<object>();
                foreach (string key in keysArr)
                {
                    var item = _distributedCache.GetString(key);
                    var deserializeObject = JsonConvert.DeserializeObject<Stock>(item);
                    list.Add(deserializeObject);
                }
                return Ok(list);
            }
            //  var existingTime = await _distributedCache.GetStringAsync(cacheKey).ConfigureAwait(false);

            //if (!string.IsNullOrEmpty(existingTime))
            //{
            //    return existingTime;
            //}
            //else
            //{
            //    return "No item exist";
            //}
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post()
        {
          
            string[] stdcodelist = { "USDTRY", "EURTRY", "EURUSD", "XU100", "XU30", "BRENT", "XGLD", "GLD" };

            Random random = new Random();
            foreach (var item in stdcodelist)
            {

                Stock stock = new Stock()
                {
                    Symbol = item,
                    Price = random.Next(100, 500)
                };
                var json = JsonConvert.SerializeObject(stock);
                await _distributedCache.SetStringAsync(item, json).ConfigureAwait(false);
                Task.Delay(50).Wait();
            }
            return Ok(true);
        }

        [HttpPost("deletekey")]
        public async Task<IActionResult> Delete(string cacheKey)
        {
            var existingTime = await _distributedCache.GetStringAsync(cacheKey).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(existingTime))
            {
                await _distributedCache.RemoveAsync(cacheKey).ConfigureAwait(false);

                return Ok(true);
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}

