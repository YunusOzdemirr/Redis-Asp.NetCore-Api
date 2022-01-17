using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacheTest.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CacheTest.Creators
{
    public class StockCreator
    {
        IDistributedCache _distributedCache;
        public StockCreator(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<Stock> Insert(string code, decimal enterValue)
        {
            List<Stock> stocks = new List<Stock>();
            var item = await _distributedCache.GetStringAsync("Stock3");
            switch (enterValue)
            {
                case > 100:
                    Stock stock = new Stock()
                    {
                        Symbol = code,
                        Price = enterValue,
                        Value = enterValue,
                        TargetLevel1 = Math.Round(enterValue * (decimal)1.006, 2),
                        TargetLevel2 = Math.Round(enterValue * (decimal)1.010, 2),
                        Stop1 = Math.Round(enterValue * (decimal)0.994, 2),
                        Stop2 = Math.Round(enterValue * (decimal)0.990, 2)
                    };
                    if (item != null)
                    {
                        var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                        var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                        if (value is not null)
                        {
                            if (value.TargetLevel2 < stock.Price || value.Stop2 > stock.Price)
                            {
                                Stock stock2 = new Stock()
                                {
                                    Symbol = code,
                                    Price = enterValue,
                                    Value = enterValue,
                                    TargetLevel1 = Math.Round(enterValue * (decimal)1.006, 2),
                                    TargetLevel2 = Math.Round(enterValue * (decimal)1.010, 2),
                                    Stop1 = Math.Round(enterValue * (decimal)0.994, 2),
                                    Stop2 = Math.Round(enterValue * (decimal)0.990, 2)
                                };

                                stocks.Add(stock2);
                                var json2 = JsonConvert.SerializeObject(stocks);
                                await _distributedCache.SetStringAsync("Stock3", json2);
                                return stock2;

                            }
                            return value;
                        }
                    }
                    stocks.Add(stock);
                    var json = JsonConvert.SerializeObject(stocks);
                    await _distributedCache.SetStringAsync("Stock3", json);
                    return stock;
                case > 50:
                    stock = new Stock()
                    {
                        Symbol = code,
                        Price = enterValue,
                        Value = enterValue,
                        TargetLevel1 = Math.Round(enterValue * (decimal)1.010, 2),
                        TargetLevel2 = Math.Round(enterValue * (decimal)1.020, 2),
                        Stop1 = Math.Round(enterValue * (decimal)0.990, 2),
                        Stop2 = Math.Round(enterValue * (decimal)0.980, 2)
                    };
                    if (item != null)
                    {
                        var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                        var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                        if (value is not null)
                        {
                            if (value.TargetLevel2 < stock.Price || value.Stop2 > stock.Price)
                            {
                                Stock stock2 = new Stock()
                                {
                                    Symbol = code,
                                    Price = enterValue,
                                    Value = enterValue,
                                    TargetLevel1 = Math.Round(enterValue * (decimal)1.010, 2),
                                    TargetLevel2 = Math.Round(enterValue * (decimal)1.020, 2),
                                    Stop1 = Math.Round(enterValue * (decimal)0.990, 2),
                                    Stop2 = Math.Round(enterValue * (decimal)0.980, 2)
                                };
                                stocks.Add(stock2);
                                var json2 = JsonConvert.SerializeObject(stocks);
                                await _distributedCache.SetStringAsync("Stock3", json2);
                                return stock2;
                            }
                            return value;
                        }
                    }
                    stocks.Add(stock);
                    json = JsonConvert.SerializeObject(stocks);
                    await _distributedCache.SetStringAsync("Stock3", json);
                    return stock;

                case > 30:
                    stock = new Stock()
                    {
                        Symbol = code,
                        Price = enterValue,
                        Value = enterValue,
                        TargetLevel1 = Math.Round(enterValue * (decimal)1.015, 2),
                        TargetLevel2 = Math.Round(enterValue * (decimal)1.030, 2),
                        Stop1 = Math.Round(enterValue * (decimal)0.985, 2),
                        Stop2 = Math.Round(enterValue * (decimal)0.970, 2)
                    };

                    if (item != null)
                    {
                        var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                        var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                        if (value is not null)
                        {
                            if (value.TargetLevel2 < stock.Price || value.Stop2 > stock.Price)
                            {
                                Stock stock2 = new Stock()
                                {
                                    Symbol = code,
                                    Price = enterValue,
                                    Value = enterValue,
                                    TargetLevel1 = Math.Round(enterValue * (decimal)1.015, 2),
                                    TargetLevel2 = Math.Round(enterValue * (decimal)1.030, 2),
                                    Stop1 = Math.Round(enterValue * (decimal)0.985, 2),
                                    Stop2 = Math.Round(enterValue * (decimal)0.970, 2)
                                };
                                stocks.Add(stock2);
                                var json2 = JsonConvert.SerializeObject(stocks);
                                await _distributedCache.SetStringAsync("Stock3", json2);
                                return stock2;
                            }
                            return value;
                        }
                    }
                    stocks.Add(stock);
                    json = JsonConvert.SerializeObject(stocks);
                    await _distributedCache.SetStringAsync("Stock3", json);
                    return stock;

                case > 20:
                    stock = new Stock()
                    {
                        Symbol = code,
                        Price = enterValue,
                        Value = enterValue,
                        TargetLevel1 = Math.Round(enterValue * (decimal)1.020, 2),
                        TargetLevel2 = Math.Round(enterValue * (decimal)1.035, 2),
                        Stop1 = Math.Round(enterValue * (decimal)0.980, 2),
                        Stop2 = Math.Round(enterValue * (decimal)0.975, 2)
                    };

                    if (item != null)
                    {
                        var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                        var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                        if (value is not null)
                        {
                            if (value.TargetLevel2 < stock.Price || value.Stop2 > stock.Price)
                            {
                                Stock stock2 = new Stock()
                                {
                                    Symbol = code,
                                    Price = enterValue,
                                    Value = enterValue,
                                    TargetLevel1 = Math.Round(enterValue * (decimal)1.020, 2),
                                    TargetLevel2 = Math.Round(enterValue * (decimal)1.035, 2),
                                    Stop1 = Math.Round(enterValue * (decimal)0.980, 2),
                                    Stop2 = Math.Round(enterValue * (decimal)0.975, 2)
                                };
                                stocks.Add(stock2);
                                var json2 = JsonConvert.SerializeObject(stocks);
                                await _distributedCache.SetStringAsync("Stock3", json2);
                                return stock2;
                            }
                            return value;
                        }
                    }
                    stocks.Add(stock);
                    json = JsonConvert.SerializeObject(stocks);
                    await _distributedCache.SetStringAsync("Stock3", json);
                    return stock;
                case > 10:
                    stock = new Stock()
                    {
                        Symbol = code,
                        Price = enterValue,
                        Value = enterValue,
                        TargetLevel1 = Math.Round(enterValue * (decimal)1.015, 2),
                        TargetLevel2 = Math.Round(enterValue * (decimal)1.025, 2),
                        Stop1 = Math.Round(enterValue * (decimal)0.985, 2),
                        Stop2 = Math.Round(enterValue * (decimal)0.975, 2)
                    };
                    if (item != null)
                    {
                        var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                        var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                        if (value is not null)
                        {
                            if (value.TargetLevel2 < stock.Price || value.Stop2 > stock.Price)
                            {
                                Stock stock2 = new Stock()
                                {
                                    Symbol = code,
                                    Price = enterValue,
                                    Value = enterValue,
                                    TargetLevel1 = Math.Round(enterValue * (decimal)1.015, 2),
                                    TargetLevel2 = Math.Round(enterValue * (decimal)1.025, 2),
                                    Stop1 = Math.Round(enterValue * (decimal)0.985, 2),
                                    Stop2 = Math.Round(enterValue * (decimal)0.975, 2)
                                };
                                stocks.Add(stock2);
                                var json2 = JsonConvert.SerializeObject(stocks);
                                await _distributedCache.SetStringAsync("Stock3", json2);

                                return stock2;
                            }

                            return value;
                        }
                    }
                    stocks.Add(stock);
                    json = JsonConvert.SerializeObject(stocks);
                    await _distributedCache.SetStringAsync("Stock3", json);
                    return stock;
                case > 3:
                    stock = new Stock()
                    {
                        Symbol = code,
                        Price = enterValue,
                        Value = enterValue,
                        TargetLevel1 = Math.Round(enterValue * (decimal)1.035, 2),
                        TargetLevel2 = Math.Round(enterValue * (decimal)1.055, 2),
                        Stop1 = Math.Round(enterValue * (decimal)0.965, 2),
                        Stop2 = Math.Round(enterValue * (decimal)0.945, 2)
                    };
                    if (item != null)
                    {
                        var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                        var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                        if (value is not null)
                        {
                            if (value.TargetLevel2 < stock.Price || value.Stop2 > stock.Price)
                            {
                                Stock stock2 = new Stock()
                                {
                                    Symbol = code,
                                    Price = enterValue,
                                    Value = enterValue,
                                    TargetLevel1 = Math.Round(enterValue * (decimal)1.035, 2),
                                    TargetLevel2 = Math.Round(enterValue * (decimal)1.055, 2),
                                    Stop1 = Math.Round(enterValue * (decimal)0.965, 2),
                                    Stop2 = Math.Round(enterValue * (decimal)0.945, 2)
                                };
                                stocks.Add(stock2);
                                var json2 = JsonConvert.SerializeObject(stocks);
                                await _distributedCache.SetStringAsync("Stock3", json2);

                                return stock2;
                            }

                            return value;
                        }
                    }
                    stocks.Add(stock);
                    json = JsonConvert.SerializeObject(stocks);
                    await _distributedCache.SetStringAsync("Stock3", json);
                    return stock;


                default:
                    stock = new Stock()
                    {
                        Symbol = code,
                        Price = enterValue,
                        Value = enterValue,
                        TargetLevel1 = Math.Round(enterValue * (decimal)1.055, 2),
                        TargetLevel2 = Math.Round(enterValue * (decimal)1.075, 2),
                        Stop1 = Math.Round(enterValue * (decimal)0.945, 2),
                        Stop2 = Math.Round(enterValue * (decimal)0.925, 2)
                    };

                    if (item != null)
                    {
                        var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                        var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                        if (value is not null)
                        {
                            if (value.TargetLevel2 < stock.Price || value.Stop2 > stock.Price)
                            {
                                Stock stock2 = new Stock()
                                {
                                    Symbol = code,
                                    Price = enterValue,
                                    Value = enterValue,
                                    TargetLevel1 = Math.Round(enterValue * (decimal)1.055, 2),
                                    TargetLevel2 = Math.Round(enterValue * (decimal)1.075, 2),
                                    Stop1 = Math.Round(enterValue * (decimal)0.945, 2),
                                    Stop2 = Math.Round(enterValue * (decimal)0.925, 2)
                                };
                                stocks.Add(stock2);
                                var json2 = JsonConvert.SerializeObject(stocks);
                                await _distributedCache.SetStringAsync("Stock3", json2);
                                return stock2;
                            }
                            return value;
                        }
                    }
                    stocks.Add(stock);
                    json = JsonConvert.SerializeObject(stocks);
                    await _distributedCache.SetStringAsync("Stock3", json);
                    return stock;
            }
        }
    }
}

