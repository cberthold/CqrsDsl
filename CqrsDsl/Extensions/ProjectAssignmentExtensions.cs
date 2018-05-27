using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl
{
    public static class ProjectAssignmentExtensions
    {
        public static ProjectAssignmentContext[] GetAllProjectAssignments(this DictionaryContext context)
        {
            return context.projectAssignment();
        }

        public static ProjectAssignmentContext GetFirstProjectAssignment(this DictionaryContext context)
        {
            return context.projectAssignment(0);
        }

        public static ProjectAssignmentContext GetProjectAssignmentItem(this DictionaryContext context, int projectPosition)
        {
            return context.projectAssignment(projectPosition);
        }

        public static string GetProjectNameText(this ProjectAssignmentContext context)
        {
            var projectName = context.projectName();
            var projectNameText = projectName.children.AggregateText();
            return projectNameText;
        }
        
    }
}
