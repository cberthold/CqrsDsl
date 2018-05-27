using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Tree;

namespace CqrsDsl
{
    public static class IParseTreeExtensions
    {
        public static string AggregateText(this IEnumerable<IParseTree> children)
        {
            var aggregate = children.Aggregate(string.Empty, (a, t) => a + t.GetText());
            return aggregate;
        }
    }
}
