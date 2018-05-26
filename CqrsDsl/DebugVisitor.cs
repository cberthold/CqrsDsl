using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CqrsDsl.Generated;

namespace CqrsDsl
{
    public class DebugVisitor : CqrsBaseVisitor<object>
    {
        public DebugVisitor()
        {
            BuildIndentValues(INITIAL_INDENT_COUNT);
        }

        public override object VisitChildren(IRuleNode node)
        {
            IncrementIndent();
            WriteConsoleText(node);
            var returnValue = base.VisitChildren(node);
            DecrementIndent();
            return returnValue;
        }

        private const string INDENT_STRING = "  ";
        private const int INITIAL_INDENT_COUNT = 20;

        public int Indents { get; private set; } = -1;

        private IDictionary<int, string> indentValues = new Dictionary<int, string>(INITIAL_INDENT_COUNT);
        private StringBuilder indentBuilder = new StringBuilder(INITIAL_INDENT_COUNT);

        private void WriteConsoleText(IParseTree node)
        {
            var indentText = GetIndentText(Indents);
            var nodeText = GetNodeText(node);
            Console.WriteLine($"{indentText}{nodeText}");
        }

        private void IncrementIndent()
        {
            Indents++;
        }

        private void DecrementIndent()
        {
            Indents--;
        }

        private string GetNodeText(IParseTree node)
        {
            var text = node.GetType().Name;

            if (node is CqrsParser.FieldPropertyNameContext propertyNameContext)
            {
                text = $"{text} - {propertyNameContext.IDENTIFIER()}";
            }
            else if (node is CqrsParser.FieldPropertyTypeContext fieldTypeContext)
            {
                text = $"{text} - {fieldTypeContext.IDENTIFIER()}";
            }
            else if (node is CqrsParser.EventNameContext eventNameContext)
            {
                text = $"{text} - {eventNameContext.IDENTIFIER()}";
            }
            else if (node is CqrsParser.CommandNameContext commandNameContext)
            {
                text = $"{text} - {commandNameContext.IDENTIFIER()}";
            }
            else if (node is CqrsParser.NamespaceNameContext namespaceNameContext)
            {
                string name = namespaceNameContext.children.Aggregate(string.Empty, (a, t) => a + t.GetText());
                text = $"{text} - {name}";
            }
            else if (node is CqrsParser.ProjectNameContext projectNameContext)
            {
                string name = projectNameContext.children.Aggregate(string.Empty, (a, t) => a + t.GetText());
                text = $"{text} - {name}";
            }
            return text;
        }

        private void BuildIndentValues(int toIndentValue, int fromIndentValue = 0)
        {

            for (var i = fromIndentValue; i < toIndentValue; i++)
            {
                indentValues.Add(i, indentBuilder.ToString());
                indentBuilder.Append(INDENT_STRING);
            }
        }

        private string GetIndentText(int indents)
        {
            if (indentValues.ContainsKey(indents))
            {
                return indentValues[indents];
            }

            var fromValue = indentValues.Count;
            var toValue = fromValue + INITIAL_INDENT_COUNT;
            BuildIndentValues(toValue, fromValue);

            return GetIndentText(indents);
        }
    }
}
