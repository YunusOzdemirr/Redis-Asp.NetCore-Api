using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CacheTest.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CacheTest.Creators
{
    public class Creator
    {
        private readonly SemaphoreSlim _marketStateLock = new SemaphoreSlim(1, 1);
        public static ConcurrentDictionary<string, Stock> _stocks = new ConcurrentDictionary<string, Stock>();
        public string CachedTimeUTC { get; set; }
        private readonly IDistributedCache _distributedCache;
        public Creator(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;

            _marketStateLock.WaitAsync();
            Post2();
            _marketStateLock.Release();
        }
        public async Task Post()
        {
            while (true)
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
                    await _distributedCache.SetStringAsync(item, json);
                    Task.Delay(50).Wait();
                }
            }
        }
      
        public List<Stock> GetAllStockAsync()
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                var keys = redis.GetServer("127.0.0.1", 6379).Keys();

                string[] keysArr = keys.Select(key => (string)key).ToArray();
                List<Stock> list = new List<Stock>();
                foreach (string key in keysArr)
                {
                    var item = _distributedCache.GetString(key);
                    var deserializeObject = JsonConvert.DeserializeObject<Stock>(item);
                    list.Add(deserializeObject);
                }
                return list;
            }
        }



        public async Task Post2()
        {
            while (true)
            {
                string[] stdcodelist = { "USDTRY", "EURTRY", "EURUSD", "XU100", "XU30", "BRENT", "XGLD", "GLD" };
                Random random = new Random();
                List<Stock> abc = new List<Stock>();

                foreach (var item in stdcodelist)
                {
                    Stock stock = new Stock()
                    {
                        Symbol = item,
                        Price = random.Next(100, 500)
                    };
                    abc.Add(stock);
                    Task.Delay(50).Wait();
                }
                var json = JsonConvert.SerializeObject(abc);
                await _distributedCache.SetStringAsync("Stocks", json);

            }
        }


        public List<Stock> GetAllStockAsync2()
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                var keys = redis.GetServer("127.0.0.1", 6379).Keys();

                string[] keysArr = keys.Select(key => (string)key).ToArray();
                    var item = _distributedCache.GetString("Stocks");
                    var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                return deserializeObject;
            }
        }
    }
}

