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

            var entityVisitor = new EntityObjectModelVisitor();

            var entityObjects = context.definitions().Select(a => entityVisitor.Visit(a));

            return builder
                .WithEntityObjects(entityObjects)
                .CurrentNamespaceModel;
        }
    }
}
