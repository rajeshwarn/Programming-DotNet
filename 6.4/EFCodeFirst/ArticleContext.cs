using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    public class ArticleContext : DbContext
    {
        public ArticleContext() 
            : base(@"Server=.\SQLEXPRESS;Database=ArticleStore;Trusted_Connection=True;") {}

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
