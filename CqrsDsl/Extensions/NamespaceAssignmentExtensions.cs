using System;
using System.Collections.Generic;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class NamespaceAssignmentExtensions
    {
        public static NamespaceAssignmentContext[] GetAllNamespaceAssignments(this DictionaryContext dictionary, int projectPosition)
        {
            return dictionary.GetProjectAssignmentItem(projectPosition).namespaceAssignment();
        }

        public static NamespaceAssignmentContext GetNamespaceAssignmentContextItem(this DictionaryContext dictionary, int projectPosition, int namespacePosition)
        {
            return dictionary.GetProjectAssignmentItem(projectPosition).namespaceAssignment(namespacePosition);
        }
        
        public static string GetNamespaceText(this NamespaceAssignmentContext context)
        {
            var namespaceName = context.namespaceName();
            var namespaceNameText = namespaceName.children.AggregateText();
            return namespaceNameText;
        }
    }
}
