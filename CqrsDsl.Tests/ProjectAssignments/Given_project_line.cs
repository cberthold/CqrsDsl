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
        public const string PROJECT_NEW_LINE = "project TestProject\r\n";
        public const string PROJECT_NO_NEW_LINE = "project TestProject";

        [Theory]
        [InlineData(PROJECT_NEW_LINE)]
        [InlineData(PROJECT_NO_NEW_LINE)]
        public void Should_Parse_Without_Exception(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
        }

        [Theory]
        [InlineData(PROJECT_NEW_LINE)]
        [InlineData(PROJECT_NO_NEW_LINE)]
        public void Should_return_one_project_assignment(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            Assert.Single(dictionary.projectAssignments());
            Assert.Single(dictionary.projectAssignments(0).projectAssignment());
        }


        [Theory]
        [InlineData(PROJECT_NEW_LINE)]
        [InlineData(PROJECT_NO_NEW_LINE)]
        public void Should_return_test_project_name(string input)
        {
            var tokenStream = GetTokenStream(input);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
            var assignment = dictionary.projectAssignments(0).projectAssignment(0);
            Assert.Equal(PROJECT_NAME, assignment.projectName().GetText());
        }
    }
}
