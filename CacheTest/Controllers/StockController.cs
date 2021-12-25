using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacheTest.Creators;
using CacheTest.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CacheTest.Controllers
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        StockCreator _stockCreator;


        public StockController(StockCreator stockCreator)
        {
            _stockCreator = stockCreator;
        }

        [HttpGet("GetAllStock")]
        public async Task<Stock> GetAllStock(string code, decimal price)
        {
            var abc = await _stockCreator.Insert(code, price);
            return abc;
        }

    }
}

