using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisferSubscriber
{   
    public class NewsArticle
    {
        public string Title { get; }
        public string Content { get; }
        public NewsArticle(string Title, string Content)
        {
            this.Title = Title;
            this.Content = Content;
        }

    }

    public class Newspublisher
    {
        public event EventHandler<NewsArticle> OnNewNewsPublished;

        public void PublishNews(string Title, string Content)
        {
            NewNewsPublished(new NewsArticle(Title, Content));
        }

        protected virtual void NewNewsPublished(NewsArticle Article)
        {
            OnNewNewsPublished?.Invoke(this,Article);
        }
    }

    public class NewsSubscriber
    {
        public string Name { get; }

        public NewsSubscriber(string Name)
        {
            this.Name = Name;
        }

        public void Sucscribe(Newspublisher publisher)
        {
            publisher.OnNewNewsPublished += HandleNewNews;
        }
        public void UnSucscribe(Newspublisher publisher)
        {
            publisher.OnNewNewsPublished -= HandleNewNews;
        }

        private void HandleNewNews(object sender, NewsArticle article)
        {
            Console.WriteLine($"{Name} Received the New Article");
            Console.WriteLine($"Title: [ {article.Title} ]");
            Console.WriteLine($"Content: [ {article.Content} ]");
            Console.WriteLine();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Newspublisher Publisher = new Newspublisher();
            NewsSubscriber Subscriber1 = new NewsSubscriber("Chouaib Hadadi");
            NewsSubscriber Subscriber2 = new NewsSubscriber("Khali Mbah");
            NewsSubscriber Subscriber3 = new NewsSubscriber("Morad AlaMdar");

            Subscriber1.Sucscribe(Publisher);
            Subscriber2.Sucscribe(Publisher);

            Publisher.PublishNews("Tech", "The Best Programming Ever Is Comming");

            
            Subscriber2.UnSucscribe(Publisher);
            Subscriber3.Sucscribe(Publisher);

            Publisher.PublishNews("Weather", "Sunny Wither Expected Tomorrow");




        }
    }
}
