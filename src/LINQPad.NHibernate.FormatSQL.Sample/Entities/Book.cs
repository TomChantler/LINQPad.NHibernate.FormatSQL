using System.Collections.Generic;
namespace LINQPad.NHibernate.FormatSQL.Sample.Entities
{
    public class Book
    {
        public virtual int Id { get; protected set; }
        public virtual string Title { get; set; }
        public virtual IList<ShortStory> ShortStories { get; set; }

        public Book()
        {
            ShortStories = new List<ShortStory>();
        }
    }
}
