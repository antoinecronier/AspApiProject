using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApiCommons.Entities
{
    public class ArticleType : DbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }
        public string Name { get; set; }
        public virtual Company Company { get; set; }
        public decimal StandardBuyingPrice { 
            get 
            {
                return 0;
            } 
        }
        public int StandardDeliveryTime
        {
            get
            {
                return 0;
            }
        }
        public virtual List<Article> Selled { get; set; } = new List<Article>();
        public virtual List<Article> InStock { get; set; } = new List<Article>();
    }
}
