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
            var propertyType = context.fieldPropertyType();
            var typeName = propertyType.GetTypeName();
            var isOptional = propertyType.IsOptional();
            var isRequired = propertyType.IsRequired();
            var isPredefinedType = propertyType.IsPredefinedType();
            return ModelFactory.CreateFieldModel(
                propertyName,
                typeName,
                isOptional,
                isRequired,
                isPredefinedType);
        }
    }
}
