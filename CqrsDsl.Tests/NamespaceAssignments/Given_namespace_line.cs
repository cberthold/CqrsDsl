using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CqrsDsl.Generated;
using Xunit;

namespace CqrsDsl.Tests.NamespaceAssignments
{
    public class Given_namespace_line : AbstractParserTest
    {
        public const string NAMESPACE_NAME = "TestNamespace";
        public const string PERIOD_NAMESPACE_NAME = "TestNamespace.Period";
        public const string UNDERSCORE_NAMESPACE_NAME = "TestNamespace_Underscore";

        public const string NAMESPACE_NEW_LINE = @"
project TestProject
    namespace TestNamespace\r\n";
        public const string NAMESPACE_NO_NEW_LINE = @"
project TestProject
    namespace TestNamespace";
        public const string NAMESPACE_PERIOD = @"
project TestProject
    namespace TestNamespace.Period";
        public const string NAMESPACE_UNDERSCORE = @"
project TestProject
    namespace TestNamespace_Underscore";

        [Theory]
        [InlineData(NAMESPACE_NEW_LINE)]
        [InlineData(NAMESPACE_NO_NEW_LINE)]
        [InlineData(NAMESPACE_PERIOD)]
        [InlineData(NAMESPACE_UNDERSCORE)]
        public void Should_parse_without_exception(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
        }

        [Theory]
        [InlineData(NAMESPACE_NEW_LINE)]
        [InlineData(NAMESPACE_NO_NEW_LINE)]
        [InlineData(NAMESPACE_PERIOD)]
        [InlineData(NAMESPACE_UNDERSCORE)]
        public void Should_return_one_namespace_assignment(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            Assert.Single(dictionary.GetAllNamespaceAssignments(0));
        }


        [Theory]
        [InlineData(NAMESPACE_NEW_LINE)]
        [InlineData(NAMESPACE_NO_NEW_LINE)]
        public void Should_return_test_namespace_name(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            var assignment = dictionary.GetNamespaceAssignmentContextItem(0, 0);
            Assert.Equal(NAMESPACE_NAME, assignment.GetNamespaceText());
        }


        [Fact]
        public void Should_return_full_namespace_name_with_period()
        {
            var tokenStream = GetTokenStream(NAMESPACE_PERIOD);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            var assignment = dictionary.GetNamespaceAssignmentContextItem(0, 0);
            Assert.Equal(PERIOD_NAMESPACE_NAME, assignment.GetNamespaceText());
        }

        [Fact]
        public void Should_return_full_namespace_name_with_underscore()
        {
            var tokenStream = GetTokenStream(NAMESPACE_UNDERSCORE);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            var assignment = dictionary.GetNamespaceAssignmentContextItem(0, 0);
            Assert.Equal(UNDERSCORE_NAMESPACE_NAME, assignment.GetNamespaceText());
        }
    }
}
