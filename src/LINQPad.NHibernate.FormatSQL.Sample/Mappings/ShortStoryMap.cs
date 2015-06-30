using FluentNHibernate.Mapping;
using LINQPad.NHibernate.FormatSQL.Sample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPad.NHibernate.FormatSQL.Sample.Mappings
{
    public class ShortStoryMap : ClassMap<ShortStory>
    {
        public ShortStoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
        }
    }
}
