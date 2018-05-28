using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using CqrsDsl.Builder;
using CqrsDsl.Generated;
using CqrsDsl.Model;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl.Visitors
{
    public class FieldModelVisitor : CqrsBaseVisitor<FieldModel>
    {
        private readonly CqrsDataModelBuilder builder;

        public FieldModelVisitor(CqrsDataModelBuilder builder)
        {
            this.builder = builder;
        }

        public override FieldModel VisitFieldDefinition([NotNull] FieldDefinitionContext context)
        {
            var propertyName = context.GetPropertyName();
            return new FieldModel(propertyName);
        }
    }
}
