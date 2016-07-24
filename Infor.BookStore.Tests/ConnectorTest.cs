using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infor.BookStore.Connectors;
using Infor.BookStore.Connectors.Format;


namespace Infor.BookStore.Tests
{
    [TestClass]
    public class ConnectorTest
    {
        private const string AbrahamFile = @"..\..\ImportFiles\A.txt";
        private const string BarackFile = @"..\..\ImportFiles\B.txt";

        [TestMethod]
        public void TestAbrahamFormat()
        {
            // Arrange
            IBookParser parser = new BookFileParser(AbrahamFile);

            // Act
            var books = parser.Parse(BookFormatFactory.Abraham, ParseOptions.TrimValue);

            // Assert            
            books.Should()
                .HaveCount(15)
                .And.ContainSingle(b => b.Name == "Charlie Bone Series" && b.Author == "Jenny Nimmo");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestBarackFormatWithNonUniformLength()
        {
            // Arrange
            IBookParser parser = new BookFileParser(BarackFile);

            // Act
            var books = parser.Parse(BookFormatFactory.Barack, ParseOptions.TrimValue);

            // Assert            
        }

        [TestMethod]
        public void TestBarackFormat()
        {
            // Arrange
            IBookParser parser = new BookFileParser(BarackFile);

            // Act
            var books = parser.Parse(BookFormatFactory.Barack, ParseOptions.TrimValue | ParseOptions.SkipUniformLengthCheck);

            // Assert           
            books.Should()
                .HaveCount(11)
                .And.ContainSingle(b => b.Name == "A Fine and Private Place" && b.Author == "Peter S. Beagle");
        }
    }
}
