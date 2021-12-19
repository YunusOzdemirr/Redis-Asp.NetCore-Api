using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheTest.Creators;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CacheTest.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        LoremCreator _loremCreator;

        public ArticlesController(LoremCreator loremCreator)
        {
            _loremCreator = loremCreator;
        }

        // GET: api/values
        [HttpGet("GetAll")]
        public async Task<string> Get()
        {
            var abc = await _loremCreator.GetAllArticle();
            return abc;
        }

        [HttpPost("Post")]
        public async Task PostArticle()
        {
           await _loremCreator.PostArticle();
        }
    }
}

