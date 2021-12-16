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
using CacheTest.Creators;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CacheTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CachesController : Controller
    {
        Creator _creator;

        public CachesController(Creator creator)
        {
            _creator = creator;
        }

        //[HttpGet("getkey")]
        //public async Task<string> Get(string cacheKey)
        //{
        //    var existingTime = await _creator.GetStringAsync(cacheKey).ConfigureAwait(false);

        //    if (!string.IsNullOrEmpty(existingTime))
        //    {
        //        return "Fetched from cache: " + existingTime;
        //    }
        //    else
        //    {
        //        return "No item exists";
        //    }
        //}




        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_creator.GetAllStockAsync2();
            if (result!=null)
            {
                return Ok(result);
            }
            return StatusCode(500);
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post()
        {
            _creator.Post();
            return Ok(true);
        }

        //[HttpPost("deletekey")]
        //public async Task<IActionResult> Delete(string cacheKey)
        //{
        //    var existingTime = await _distributedCache.GetStringAsync(cacheKey).ConfigureAwait(false);

        //    if (!string.IsNullOrEmpty(existingTime))
        //    {
        //        await _distributedCache.RemoveAsync(cacheKey).ConfigureAwait(false);

        //        return Ok(true);
        //    }
        //    else
        //    {
        //        return this.NotFound();
        //    }
        //}
    }
}

