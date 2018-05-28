using System;
using System.Collections.Generic;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class DataTransferObjectDefinitionExtensions
    {
        public static string GetDataTransferObjectNameText(this DataTransferObjectDefinitionContext context)
        {
            var dataTransferObjectName = context.dataTransferObjectName();
            var dataTransferObjectNameText = dataTransferObjectName.children.AggregateText();
            return dataTransferObjectNameText;
        }
    }
}
