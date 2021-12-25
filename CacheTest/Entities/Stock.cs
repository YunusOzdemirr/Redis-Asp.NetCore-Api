using System;
namespace CacheTest.Entities
{
    public class Stock
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal LastPrice { get; set; }
        public decimal Value { get; set; }
        public decimal TargetLevel1 { get; set; }
        public decimal TargetLevel2 { get; set; }
        public decimal Stop1 { get; set; }
        public decimal Stop2 { get; set; }
    }
}

