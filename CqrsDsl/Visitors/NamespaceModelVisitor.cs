using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using CqrsDsl.Builder;
using CqrsDsl.Generated;
using CqrsDsl.Model;

namespace CqrsDsl.Visitors
{
    public class NamespaceModelVisitor : CqrsBaseVisitor<NamespaceModel>
    {

        private readonly CqrsDataModelBuilder builder;

        public NamespaceModelVisitor(CqrsDataModelBuilder builder)
        {
            this.builder = builder;
        }

        public override NamespaceModel VisitNamespaceAssignment([NotNull] CqrsParser.NamespaceAssignmentContext context)
        {
            builder.SetCurrentNamespace(context.GetNamespaceText());

            return builder.CurrentNamespaceModel;
        }
    }
}
