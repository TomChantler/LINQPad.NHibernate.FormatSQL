using FluentNHibernate.Mapping;
using LINQPad.NHibernate.FormatSQL.Sample.Entities;

namespace LINQPad.NHibernate.FormatSQL.Sample.Mappings
{
    public class BookMap: ClassMap<Book>
    {
        public BookMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            HasMany(x => x.ShortStories)
                .Cascade.All();
        }
    }
}
