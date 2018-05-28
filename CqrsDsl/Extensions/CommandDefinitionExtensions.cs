using System;
using System.Collections.Generic;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class CommandDefinitionExtensions
    {
        public static string GetCommandNameText(this CommandDefinitionContext context)
        {
            var commandName = context.commandName();
            var commandNameText = commandName.children.AggregateText();
            return commandNameText;
        }
    }
}
