using System;
using System.Collections.Generic;
using System.Text;
using CqrsDsl.Generated;
using Xunit;

namespace CqrsDsl.Tests.ProjectAssignments
{
    public class Given_project_line : AbstractParserTest
    {
        public const string PROJECT_NAME = "TestProject";
        public const string PERIOD_PROJECT_NAME = "TestProject.Period";
        public const string UNDERSCORE_PROJECT_NAME = "TestProject_Underscore";

        public const string PROJECT_NEW_LINE = "project TestProject\r\n";
        public const string PROJECT_NO_NEW_LINE = "project TestProject";
        public const string PROJECT_PERIOD = "project TestProject.Period";
        public const string PROJECT_UNDERSCORE = "project TestProject_Underscore";

        [Theory]
        [InlineData(PROJECT_NEW_LINE)]
        [InlineData(PROJECT_NO_NEW_LINE)]
        [InlineData(PROJECT_PERIOD)]
        [InlineData(PROJECT_UNDERSCORE)]
        public void Should_parse_without_exception(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
        }

        [Theory]
        [InlineData(PROJECT_NEW_LINE)]
        [InlineData(PROJECT_NO_NEW_LINE)]
        [InlineData(PROJECT_PERIOD)]
        [InlineData(PROJECT_UNDERSCORE)]
        public void Should_return_one_project_assignment(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            Assert.Single(dictionary.GetAllProjectAssignments());
        }


        [Theory]
        [InlineData(PROJECT_NEW_LINE)]
        [InlineData(PROJECT_NO_NEW_LINE)]
        public void Should_return_test_project_name(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            var assignment = dictionary.GetProjectAssignmentItem(0);
            Assert.Equal(PROJECT_NAME, assignment.GetProjectNameText());
        }


        [Fact]
        public void Should_return_full_project_name_with_period()
        {
            var tokenStream = GetTokenStream(PROJECT_PERIOD);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            var assignment = dictionary.GetProjectAssignmentItem(0);
            Assert.Equal(PERIOD_PROJECT_NAME, assignment.GetProjectNameText());
        }

        [Fact]
        public void Should_return_full_project_name_with_underscore()
        {
            var tokenStream = GetTokenStream(PROJECT_UNDERSCORE);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            var assignment = dictionary.GetProjectAssignmentItem(0);
            Assert.Equal(UNDERSCORE_PROJECT_NAME, assignment.GetProjectNameText());
        }
    }
}
