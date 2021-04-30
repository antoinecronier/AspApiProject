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
        public List<Article> Selled
        {
            get
            {
                return null;
            }
        }
        public List<Article> InStock
        {
            get
            {
                return null;
            }
        }
    }
}
