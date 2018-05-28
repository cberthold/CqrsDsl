using System;
using System.Collections.Generic;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class ValueObjectDefinitionExtensions
    {
        public static string GetValueObjectNameText(this ValueObjectDefinitionContext context)
        {
            var valueObjectName = context.valueObjectName();
            var valueObjectNameText = valueObjectName.children.AggregateText();
            return valueObjectNameText;
        }
    }
}
