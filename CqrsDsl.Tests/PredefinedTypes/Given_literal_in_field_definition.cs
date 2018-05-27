using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CqrsDsl.Generated;
using Xunit;

namespace CqrsDsl.Tests.PredefinedTypes
{
    public class Given_literal_in_field_definition : AbstractParserTest
    {
        [Theory]
        [InlineData("System.Guid")]
        [InlineData("Guid")]
        [InlineData("string")]
        [InlineData("System.String")]
        [InlineData("String")]
        [InlineData("object")]
        [InlineData("System.Object")]
        [InlineData("Object")]
        [InlineData("sbyte")]
        [InlineData("System.SByte")]
        [InlineData("SByte")]
        [InlineData("byte")]
        [InlineData("System.Byte")]
        [InlineData("Byte")]
        [InlineData("short")]
        [InlineData("System.Int16")]
        [InlineData("Int16")]
        [InlineData("ushort")]
        [InlineData("System.UInt16")]
        [InlineData("UInt16")]
        [InlineData("int")]
        [InlineData("System.Int32")]
        [InlineData("Int32")]
        [InlineData("uint")]
        [InlineData("System.UInt32")]
        [InlineData("UInt32")]
        [InlineData("long")]
        [InlineData("System.Int64")]
        [InlineData("Int64")]
        [InlineData("ulong")]
        [InlineData("System.UInt64")]
        [InlineData("UInt64")]
        [InlineData("char")]
        [InlineData("System.Char")]
        [InlineData("Char")]
        [InlineData("float")]
        [InlineData("System.Single")]
        [InlineData("Single")]
        [InlineData("double")]
        [InlineData("System.Double")]
        [InlineData("Double")]
        [InlineData("bool")]
        [InlineData("System.Boolean")]
        [InlineData("Boolean")]
        [InlineData("decimal")]
        [InlineData("System.Decimal")]
        [InlineData("Decimal")]
        [InlineData("System.DateTime")]
        [InlineData("DateTime")]
        [InlineData("datetime")]
        [InlineData("localdatetime")]
        [InlineData("date")]
        [InlineData("localdate")]
        [InlineData("time")]
        [InlineData("localtime")]
        public void Should_compile_example_code_without_exception(string inputLiteral)
        {
            var inputCode = CreateCodeWithFieldDefinitionFromLiteral(inputLiteral);
            var tokenStream = GetTokenStream(inputCode);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();
        }

        [Theory]
        [InlineData("System.Guid")]
        [InlineData("Guid")]
        [InlineData("string")]
        [InlineData("System.String")]
        [InlineData("String")]
        [InlineData("object")]
        [InlineData("System.Object")]
        [InlineData("Object")]
        [InlineData("sbyte")]
        [InlineData("System.SByte")]
        [InlineData("SByte")]
        [InlineData("byte")]
        [InlineData("System.Byte")]
        [InlineData("Byte")]
        [InlineData("short")]
        [InlineData("System.Int16")]
        [InlineData("Int16")]
        [InlineData("ushort")]
        [InlineData("System.UInt16")]
        [InlineData("UInt16")]
        [InlineData("int")]
        [InlineData("System.Int32")]
        [InlineData("Int32")]
        [InlineData("uint")]
        [InlineData("System.UInt32")]
        [InlineData("UInt32")]
        [InlineData("long")]
        [InlineData("System.Int64")]
        [InlineData("Int64")]
        [InlineData("ulong")]
        [InlineData("System.UInt64")]
        [InlineData("UInt64")]
        [InlineData("char")]
        [InlineData("System.Char")]
        [InlineData("Char")]
        [InlineData("float")]
        [InlineData("System.Single")]
        [InlineData("Single")]
        [InlineData("double")]
        [InlineData("System.Double")]
        [InlineData("Double")]
        [InlineData("bool")]
        [InlineData("System.Boolean")]
        [InlineData("Boolean")]
        [InlineData("decimal")]
        [InlineData("System.Decimal")]
        [InlineData("Decimal")]
        [InlineData("System.DateTime")]
        [InlineData("DateTime")]
        [InlineData("datetime")]
        [InlineData("localdatetime")]
        [InlineData("date")]
        [InlineData("localdate")]
        [InlineData("time")]
        [InlineData("localtime")]
        public void Should_return_field1_as_being_predefined_type(string inputLiteral)
        {
            var inputCode = CreateCodeWithFieldDefinitionFromLiteral(inputLiteral);
            var tokenStream = GetTokenStream(inputCode);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();

            var namespaceAssignment = dictionary.GetNamespaceAssignmentContextItem(0, 0);
            var commandAssignment = namespaceAssignment.definitions(0).commandDefinition();

            Assert.Collection(commandAssignment.fieldDefinition().Select(a => a.fieldPropertyType()),
                // first field
                (f) =>
                {
                    Assert.True(f.IsPredefinedType());
                },
                // second field
                (f) =>
                {
                    Assert.False(f.IsPredefinedType());
                });
        }

        [Theory]
        [InlineData("System.Guid")]
        [InlineData("Guid")]
        [InlineData("string")]
        [InlineData("System.String")]
        [InlineData("String")]
        [InlineData("object")]
        [InlineData("System.Object")]
        [InlineData("Object")]
        [InlineData("sbyte")]
        [InlineData("System.SByte")]
        [InlineData("SByte")]
        [InlineData("byte")]
        [InlineData("System.Byte")]
        [InlineData("Byte")]
        [InlineData("short")]
        [InlineData("System.Int16")]
        [InlineData("Int16")]
        [InlineData("ushort")]
        [InlineData("System.UInt16")]
        [InlineData("UInt16")]
        [InlineData("int")]
        [InlineData("System.Int32")]
        [InlineData("Int32")]
        [InlineData("uint")]
        [InlineData("System.UInt32")]
        [InlineData("UInt32")]
        [InlineData("long")]
        [InlineData("System.Int64")]
        [InlineData("Int64")]
        [InlineData("ulong")]
        [InlineData("System.UInt64")]
        [InlineData("UInt64")]
        [InlineData("char")]
        [InlineData("System.Char")]
        [InlineData("Char")]
        [InlineData("float")]
        [InlineData("System.Single")]
        [InlineData("Single")]
        [InlineData("double")]
        [InlineData("System.Double")]
        [InlineData("Double")]
        [InlineData("bool")]
        [InlineData("System.Boolean")]
        [InlineData("Boolean")]
        [InlineData("decimal")]
        [InlineData("System.Decimal")]
        [InlineData("Decimal")]
        [InlineData("System.DateTime")]
        [InlineData("DateTime")]
        [InlineData("datetime")]
        [InlineData("localdatetime")]
        [InlineData("date")]
        [InlineData("localdate")]
        [InlineData("time")]
        [InlineData("localtime")]
        public void Should_return_fields_as_being_required_when_required_fragment_added(string inputLiteral)
        {
            const string REQUIRED_LITERAL = "!";
            var inputCode = CreateCodeWithFieldDefinitionFromLiteral(inputLiteral, REQUIRED_LITERAL);

            var tokenStream = GetTokenStream(inputCode);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();

            var namespaceAssignment = dictionary.GetNamespaceAssignmentContextItem(0, 0);
            var commandAssignment = namespaceAssignment.definitions(0).commandDefinition();

            Assert.Collection(commandAssignment.fieldDefinition().Select(a => a.fieldPropertyType()),
                // first field
                (f) =>
                {
                    Assert.True(f.IsRequired());
                },
                // second field
                (f) =>
                {
                    Assert.True(f.IsRequired());
                });
        }

        [Theory]
        [InlineData("System.Guid")]
        [InlineData("Guid")]
        [InlineData("string")]
        [InlineData("System.String")]
        [InlineData("String")]
        [InlineData("object")]
        [InlineData("System.Object")]
        [InlineData("Object")]
        [InlineData("sbyte")]
        [InlineData("System.SByte")]
        [InlineData("SByte")]
        [InlineData("byte")]
        [InlineData("System.Byte")]
        [InlineData("Byte")]
        [InlineData("short")]
        [InlineData("System.Int16")]
        [InlineData("Int16")]
        [InlineData("ushort")]
        [InlineData("System.UInt16")]
        [InlineData("UInt16")]
        [InlineData("int")]
        [InlineData("System.Int32")]
        [InlineData("Int32")]
        [InlineData("uint")]
        [InlineData("System.UInt32")]
        [InlineData("UInt32")]
        [InlineData("long")]
        [InlineData("System.Int64")]
        [InlineData("Int64")]
        [InlineData("ulong")]
        [InlineData("System.UInt64")]
        [InlineData("UInt64")]
        [InlineData("char")]
        [InlineData("System.Char")]
        [InlineData("Char")]
        [InlineData("float")]
        [InlineData("System.Single")]
        [InlineData("Single")]
        [InlineData("double")]
        [InlineData("System.Double")]
        [InlineData("Double")]
        [InlineData("bool")]
        [InlineData("System.Boolean")]
        [InlineData("Boolean")]
        [InlineData("decimal")]
        [InlineData("System.Decimal")]
        [InlineData("Decimal")]
        [InlineData("System.DateTime")]
        [InlineData("DateTime")]
        [InlineData("datetime")]
        [InlineData("localdatetime")]
        [InlineData("date")]
        [InlineData("localdate")]
        [InlineData("time")]
        [InlineData("localtime")]
        public void Should_return_fields_as_being_required_when_optional_fragment_added(string inputLiteral)
        {
            const string OPTIONAL_LITERAL = "?";
            var inputCode = CreateCodeWithFieldDefinitionFromLiteral(inputLiteral, OPTIONAL_LITERAL);
            var tokenStream = GetTokenStream(inputCode);
            var parser = new CqrsParser(tokenStream);
            var dictionary = parser.dictionary();

            var namespaceAssignment = dictionary.GetNamespaceAssignmentContextItem(0, 0);
            var commandAssignment = namespaceAssignment.definitions(0).commandDefinition();

            Assert.Collection(commandAssignment.fieldDefinition().Select(a => a.fieldPropertyType()),
                // first field
                (f) =>
                {
                    Assert.True(f.IsOptional());
                },
                // second field
                (f) =>
                {
                    Assert.True(f.IsOptional());
                });
        }

        private string CreateCodeWithFieldDefinitionFromLiteral(string literal, string forcedLanguage = "")
        {
            var returnString = $@"project Example1
	namespace Example1.Level1.Commands
		command-def CreateExampleCommand : field1 {literal}{forcedLanguage}, field2 NOT_LITERAL{forcedLanguage}";
            return returnString;
        }
    }
}
