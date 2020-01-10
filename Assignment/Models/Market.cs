using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Market
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Coin> Coins { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAd { get; set; }
        public int Status { get; set; }

        public Market()
        {
            CreatedAt = DateTime.Now;
            UpdatedAd = DateTime.Now;
            Status = 1;
        }
    }
    
}