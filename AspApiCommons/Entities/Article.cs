using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApiCommons.Entities
{
    public class Article : DbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime SelledAt { get; set; }
        public DateTime DeliveryAt { get; set; }
        public ArticleType ArticleType { get; set; }
    }
}
