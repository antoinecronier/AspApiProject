using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "datetime2")]
        public DateTime SelledAt { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DeliveryAt { get; set; }
        [JsonIgnore]
        public virtual ArticleType ArticleType { get; set; }
    }
}
