using AspApiCommons.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspApiBackend.Data
{
    public class AspApiBackendContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AspApiBackendContext() : base("name=AspApiBackendContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;

            if (this.Database.CreateIfNotExists())
            {
                Company c1 = new Company { Name = "mycompany", Siret = "63259801423659", Address = "labas quelque part" };
                this.Companies.Add(c1);

                this.SaveChanges();
                c1 = this.Companies.FirstOrDefault();

                List<ArticleType> articlesTypes = new List<ArticleType>();

                for (int i = 0; i < 10; i++)
                {
                    articlesTypes.Add(new ArticleType
                    {
                        Company = c1,
                        Name = "article t " + i
                    });
                }
                this.ArticleTypes.AddRange(articlesTypes);

                this.SaveChanges();
                articlesTypes = this.ArticleTypes.ToList();

                List<Article> articles = new List<Article>();
                for (int i = 0; i < 120; i++)
                {
                    var at = articlesTypes.ElementAt(i % articlesTypes.Count);
                    Article a = new Article
                    {
                        ArticleType = at,
                        Name = at.Name,
                        Price = 20 * i % 120,
                    };

                    if (i % 4 == 0)
                    {
                        a.SelledAt = DateTime.Now.AddDays(-((i * 3) % 90));
                        a.DeliveryAt = DateTime.Now.AddDays(-((i * 3) % 90) + (i * 3 % 15));
                        at.Selled.Add(a);
                    }
                    else
                    {
                        at.InStock.Add(a);
                    }
                    articles.Add(a);
                }

                this.Articles.AddRange(articles);
                this.SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AspApiCommons.Entities.ArticleType>().HasMany(x => x.InStock).WithRequired(x => x.ArticleType);
            modelBuilder.Entity<AspApiCommons.Entities.ArticleType>().HasMany(x => x.Selled).WithOptional();
        }

        public System.Data.Entity.DbSet<AspApiCommons.Entities.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<AspApiCommons.Entities.ArticleType> ArticleTypes { get; set; }

        public System.Data.Entity.DbSet<AspApiCommons.Entities.Article> Articles { get; set; }
    }
}
