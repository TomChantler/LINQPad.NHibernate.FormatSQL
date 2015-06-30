using FluentNHibernate.Mapping;
using LINQPad.NHibernate.FormatSQL.Sample.Entities;

namespace LINQPad.NHibernate.FormatSQL.Sample.Mappings
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Books)
                .Cascade.All();
        }
    }
}
