using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LINQPad.NHibernate.FormatSQL.Sample.Entities;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQPad.NHibernate.FormatSQL.Sample
{
    public class Main
    {
        private static string dbFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\LINQPadNHibernateFormatSQLSample.db";
        private static ISessionFactory sessionFactory;

        public static void Setup()
        {
            sessionFactory = CreateSessionFactory();

            var session = sessionFactory.OpenSession();
            {
                using (var transaction = session.BeginTransaction())
                {
                    var arthurConanDoyle = new Author
                    {
                        Title = "Sir",
                        FirstName = "Arthur",
                        LastName = "Conan Doyle",
                        Books = new List<Book> {
                                    new Book { Title= "A Study in Scarlet" },
                                    new Book { Title= "The Sign of Four" },
                                    new Book { Title= "The Hound of the Baskervilles" },
                                    new Book { Title= "The Valley of Fear" },
                                    new Book { Title= "The Adventures of Sherlock Holmes", 
                                        ShortStories = new List<ShortStory> {
                                        new ShortStory { Title = "A Scandal in Bohemia" },
                                        new ShortStory { Title = "The Adventure of the Red-Headed League" },
                                        new ShortStory { Title = "A Case of Identity" },
                                        new ShortStory { Title = "The Boscombe Valley Mystery" },
                                        new ShortStory { Title = "The Five Orange Pips" },
                                        new ShortStory { Title = "The Man with the Twisted Lip" },
                                        new ShortStory { Title = "The Adventure of the Blue Carbuncle" },
                                        new ShortStory { Title = "The Adventure of the Speckled Band" },
                                        new ShortStory { Title = "The Adventure of the Engineer's Thumb" },
                                        new ShortStory { Title = "The Adventure of the Noble Bachelor" },
                                        new ShortStory { Title = "The Adventure of the Beryl Coronet" },
                                        new ShortStory { Title = "The Adventure of the Copper Beeches" }
                                        }
                                    }
                        }
                    };

                    session.SaveOrUpdate(arthurConanDoyle);
                    transaction.Commit();
                }
            }
        }

        public static IList<Author> Get(bool setupDatabase = false)
        {
            if (setupDatabase)
            {
                Setup();
            }

            var session = sessionFactory.OpenSession();
            {
                return session.CreateCriteria<Author>().List<Author>().ToList();
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(dbFile)
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Author>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (File.Exists(dbFile))
            {
                File.Delete(dbFile);
            }

            new SchemaExport(config).Create(false, true);
        }
    }
}
