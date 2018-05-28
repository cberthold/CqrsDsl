using System;
using System.Collections.Generic;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class EventDefinitionExtensions
    {
        public static string GetEventNameText(this EventDefinitionContext context)
        {
            var eventName = context.eventName();
            var eventNameText = eventName.children.AggregateText();
            return eventNameText;
        }
    }
}
