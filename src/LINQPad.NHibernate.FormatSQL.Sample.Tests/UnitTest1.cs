using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQPad.NHibernate.FormatSQL.Sample.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var authors = LINQPad.NHibernate.FormatSQL.Sample.Main.Get();
            Assert.AreEqual(1, authors.Count);
        }
    }
}
