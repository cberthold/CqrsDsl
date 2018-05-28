using System;
using System.Collections.Generic;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class FieldPropertyTypeExtensions
    {
        public static bool IsPredefinedType(this FieldPropertyTypeContext context)
        {
            return context.GetTokens(PREDEFINED_TYPE).Length == 1;
        }

        public static bool IsOptional(this FieldPropertyTypeContext context)
        {
            return context.GetTokens(OPTIONAL).Length == 1;
        }

        public static bool IsRequired(this FieldPropertyTypeContext context)
        {
            return context.GetTokens(REQUIRED).Length == 1;
        }

        public static string GetTypeName(this FieldPropertyTypeContext context)
        {
            var typeNameText = context.children.AggregateText();
            return typeNameText;
        }
    }
}
