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
            if (enterValue>100)
            {
                Stock stock = new Stock()
                {
                    Symbol = code,
                    Price = enterValue,
                    Value = enterValue,
                    TargetLevel1 = Math.Round(enterValue * (decimal)1.012,2),
                    TargetLevel2 = Math.Round(enterValue * (decimal)1.045,2),
                    Stop1 = Math.Round(enterValue * (decimal)0.977,2),
                    Stop2 = Math.Round(enterValue * (decimal)0.95,2)
                };
                var item = await _distributedCache.GetStringAsync("Stock3");

                if (item != null)
                {
                    var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                    var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                    if (value is not null)
                    {
                        if (value.TargetLevel2 < stock.Price || value.Stop2>stock.Price)
                        {
                            Stock stock2 = new Stock()
                            {
                                Symbol = code,
                                Price = enterValue,
                                Value = enterValue,
                                TargetLevel1 = Math.Round(enterValue * (decimal)1.012, 2),
                                TargetLevel2 = Math.Round(enterValue * (decimal)1.045, 2),
                                Stop1 = Math.Round(enterValue * (decimal)0.977, 2),
                                Stop2 = Math.Round(enterValue * (decimal)0.95, 2)
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
            }
            else if (enterValue > 50)
            {
                Stock stock = new Stock()
                {
                    Symbol = code,
                    Price = enterValue,
                    Value = enterValue,
                    TargetLevel1 = Math.Round(enterValue * (decimal)1.032, 2),
                    TargetLevel2 = Math.Round(enterValue * (decimal)1.078, 2),
                    Stop1 = Math.Round(enterValue * (decimal)0.969, 2),
                    Stop2 = Math.Round(enterValue * (decimal)0.930, 2)
                };
                var item = await _distributedCache.GetStringAsync("Stock3");

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
                                TargetLevel1 = Math.Round(enterValue * (decimal)1.032, 2),
                                TargetLevel2 = Math.Round(enterValue * (decimal)1.078, 2),
                                Stop1 = Math.Round(enterValue * (decimal)0.969, 2),
                                Stop2 = Math.Round(enterValue * (decimal)0.930, 2)
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
            }
            else if (enterValue > 30)
            {
                Stock stock = new Stock()
                {
                    Symbol = code,
                    Price = enterValue,
                    Value = enterValue,
                    TargetLevel1 = Math.Round(enterValue * (decimal)1.041, 2),
                    TargetLevel2 = Math.Round(enterValue * (decimal)1.082, 2),
                    Stop1 = Math.Round(enterValue * (decimal)0.976, 2),
                    Stop2 = Math.Round(enterValue * (decimal)0.948, 2)
                };
                var item = await _distributedCache.GetStringAsync("Stock3");

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
                                TargetLevel1 = Math.Round(enterValue * (decimal)1.041, 2),
                                TargetLevel2 = Math.Round(enterValue * (decimal)1.082, 2),
                                Stop1 = Math.Round(enterValue * (decimal)0.976, 2),
                                Stop2 = Math.Round(enterValue * (decimal)0.948, 2)
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
            }
            else if (enterValue > 20)
            {
                Stock stock = new Stock()
                {
                    Symbol = code,
                    Price = enterValue,
                    Value = enterValue,
                    TargetLevel1 = Math.Round(enterValue * (decimal)1.051,2),
                    TargetLevel2 = Math.Round(enterValue * (decimal)1.092,2),
                    Stop1 = Math.Round(enterValue * (decimal)0.95,2),
                    Stop2 = Math.Round(enterValue * (decimal)0.92,2)
                };
                var item = await _distributedCache.GetStringAsync("Stock3");

                if (item != null)
                {
                    var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                    var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                    if (value is not null)
                    {
                        if (value.TargetLevel2 < stock.Price || value.Stop2>stock.Price)
                        {
                            Stock stock2 = new Stock()
                            {
                                Symbol = code,
                                Price = enterValue,
                                Value = enterValue,
                                TargetLevel1 = Math.Round(enterValue * (decimal)1.035,2),
                                TargetLevel2 = Math.Round(enterValue * (decimal)1.092,2),
                                Stop1 = Math.Round(enterValue * (decimal)0.95,2),
                                Stop2 = Math.Round(enterValue * (decimal)0.92,2)
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
            }
            else if (enterValue > 10)
            {
                Stock stock = new Stock()
                {
                    Symbol = code,
                    Price = enterValue,
                    Value = enterValue,
                    TargetLevel1 = Math.Round(enterValue * (decimal)1.055, 2),
                    TargetLevel2 = Math.Round(enterValue * (decimal)1.10, 2),
                    Stop1 = Math.Round(enterValue * (decimal)0.952, 2),
                    Stop2 = Math.Round(enterValue * (decimal)0.92, 2)
                };
                var item = await _distributedCache.GetStringAsync("Stock3");

                if (item != null)
                {
                    var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                    var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                    if (value is not null)
                    {
                        if (value.TargetLevel2 < stock.Price|| value.Stop2>stock.Price)
                        {
                            Stock stock2 = new Stock()
                            {
                                Symbol = code,
                                Price = enterValue,
                                Value = enterValue,
                                TargetLevel1 = Math.Round(enterValue * (decimal)1.055, 2),
                                TargetLevel2 = Math.Round(enterValue * (decimal)1.10, 2),
                                Stop1 = Math.Round(enterValue * (decimal)0.952, 2),
                                Stop2 = Math.Round(enterValue * (decimal)0.92, 2)
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
            }
            else if (enterValue>3)
            {
                Stock stock = new Stock()
                {
                    Symbol = code,
                    Price = enterValue,
                    Value = enterValue,
                    TargetLevel1 = Math.Round(enterValue * (decimal)1.06, 2),
                    TargetLevel2 = Math.Round(enterValue * (decimal)1.126, 2),
                    Stop1 = Math.Round(enterValue * (decimal)0.92, 2),
                    Stop2 = Math.Round(enterValue * (decimal)0.86, 2)
                };
                var item = await _distributedCache.GetStringAsync("Stock3");

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
                                TargetLevel1 = Math.Round(enterValue * (decimal)1.06, 2),
                                TargetLevel2 = Math.Round(enterValue * (decimal)1.126, 2),
                                Stop1 = Math.Round(enterValue * (decimal)0.92, 2),
                                Stop2 = Math.Round(enterValue * (decimal)0.86, 2)
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
            }
            else 
            {
                Stock stock = new Stock()
                {
                    Symbol = code,
                    Price = enterValue,
                    Value = enterValue,
                    TargetLevel1 = Math.Round(enterValue * (decimal)1.15,2),
                    TargetLevel2 = Math.Round(enterValue * (decimal)1.32,2),
                    Stop1 = Math.Round(enterValue * (decimal)0.84,2),
                    Stop2 = Math.Round(enterValue * (decimal)0.74,2)
                };
                var item = await _distributedCache.GetStringAsync("Stock3");

                if (item != null)
                {
                    var deserializeObject = JsonConvert.DeserializeObject<List<Stock>>(item);
                    var value = deserializeObject.SingleOrDefault(a => a.Symbol == code);
                    if (value is not null)
                    {
                        if (value.TargetLevel2 < stock.Price || value.Stop2>stock.Price)
                        {
                            Stock stock2 = new Stock()
                            {
                                Symbol = code,
                                Price = enterValue,
                                Value = enterValue,
                                TargetLevel1 = Math.Round(enterValue * (decimal)1.15, 2),
                                TargetLevel2 = Math.Round(enterValue * (decimal)1.32, 2),
                                Stop1 = Math.Round(enterValue * (decimal)0.865, 2),
                                Stop2 = Math.Round(enterValue * (decimal)0.746, 2)
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
            }
        }
    }
}

