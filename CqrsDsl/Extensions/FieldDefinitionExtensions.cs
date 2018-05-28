using System;
using System.Collections.Generic;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class FieldDefinitionExtensions
    {
        public static string GetPropertyName(this FieldDefinitionContext context)
        {
            var propertyName = context.fieldPropertyName();
            var propertyNameText = propertyName.children.AggregateText();
            return propertyNameText;
        }
    }
}
