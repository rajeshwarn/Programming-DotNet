using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var article = new Article
            {
                Title = "Fourth Article",
                Content = "Fourth article content",
                Author = new Author { DisplayName = "Jane Doe", UserName = "janedoe" }
            };


            CreateArticle(article);

            Console.ReadLine();
        }

        static Article GetArticleById(int id)
        {
            using (var db = new ArticleContext())
            {
                return db.Articles
                    .Include("Author")
                    .SingleOrDefault(a => a.Id == id);
            }
        }

        static void CreateArticle(Article article)
        {
            using (var db = new ArticleContext())
            {
                db.Articles.Add(article);

                db.SaveChanges();

            }
        }

        static void UpdateArticle(Article article)
        {
            using (var db = new ArticleContext())
            {
                db.Articles.Attach(article);
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        static void DeleteArticle(Article article)
        {
            using (var db = new ArticleContext())
            {
                db.Articles.Attach(article);
                db.Articles.Remove(article);
                //db.Entry(article).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        static Author GetAuthorById(int id)
        {
            using (var db = new ArticleContext())
            {
                return db.Authors
                    .Include("Articles")
                    .SingleOrDefault(a => a.Id == id);
            }
        }
    }
}
