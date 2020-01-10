using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Coin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BaseAsset { get; set; }
        public string QuoteAsset { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]

        public long LastPrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]

        public long Volum24h { get; set; }
        public string MarketId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAd { get; set; }
        public int Status { get; set; }
        public virtual Market Market { get; set; }

        public Coin()
        {
            CreatedAt = DateTime.Now;
            UpdatedAd = DateTime.Now;
            Status = 1;
        }
    }
}