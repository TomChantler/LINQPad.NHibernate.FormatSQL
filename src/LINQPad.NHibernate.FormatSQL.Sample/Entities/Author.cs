using System.Collections.Generic;

namespace LINQPad.NHibernate.FormatSQL.Sample.Entities
{
    public class Author
    {
        public virtual int Id { get; protected set; }
        public virtual string Title { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}
