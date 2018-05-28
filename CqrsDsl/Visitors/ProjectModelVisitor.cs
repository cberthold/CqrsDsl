using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using CqrsDsl.Builder;
using CqrsDsl.Generated;
using CqrsDsl.Model;

namespace CqrsDsl.Visitors
{
    public class ProjectModelVisitor : CqrsBaseVisitor<ProjectModel>
    {

        private readonly CqrsDataModelBuilder builder;

        public ProjectModelVisitor(CqrsDataModelBuilder builder)
        {
            this.builder = builder;
        }

        public override ProjectModel VisitProjectAssignment([NotNull] CqrsParser.ProjectAssignmentContext context)
        {
            builder.SetCurrentProject(context.GetProjectNameText());

            var visitor = new NamespaceModelVisitor(builder);

            var namespaces = context.namespaceAssignment().Select(a => visitor.Visit(a));

            return builder
                .WithNamespaces(namespaces)
                .CurrentProjectModel;
        }
    }
}
