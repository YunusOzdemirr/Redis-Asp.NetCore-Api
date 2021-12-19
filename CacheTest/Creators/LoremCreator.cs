using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CacheTest.Creators
{
    public class LoremCreator
    {
        IDistributedCache _distributedCache;
public LoremCreator(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task<string> GetAllArticle()
        {
           var articles= await _distributedCache.GetStringAsync("Articles");
            var convertJson = JsonConvert.DeserializeObject<StringBuilder>(articles);
            return convertJson.ToString();
        }

        public async Task PostArticle()
        {
            int length = 1000;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            var json = JsonConvert.SerializeObject(str_build);
            await _distributedCache.SetStringAsync("Articles", json);
        }
    }
}

