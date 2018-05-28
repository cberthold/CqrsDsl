using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using CqrsDsl.Builder;
using CqrsDsl.Generated;
using CqrsDsl.Model;
using static CqrsDsl.Generated.CqrsParser;

namespace CqrsDsl.Visitors
{
    public class EntityObjectModelVisitor : CqrsBaseVisitor<EntityObjectModel>
    {

        public FieldDefinitionContext[] CurrentFieldDefinitions { get; private set; } = new FieldDefinitionContext[0];

        private readonly CqrsDataModelBuilder builder;
        private readonly FieldModelVisitor fieldModelVisitor;

        public EntityObjectModelVisitor(CqrsDataModelBuilder builder)
        {
            this.builder = builder;
            fieldModelVisitor = new FieldModelVisitor(builder);
        }

        public override EntityObjectModel VisitDefinitions([NotNull] DefinitionsContext context)
        {
            var model = base.VisitDefinitions(context);

            var fields = CurrentFieldDefinitions.Select(a => fieldModelVisitor.Visit(a));
            
            return model
                .WithFields(fields);
        }

        public override EntityObjectModel VisitCommandDefinition([NotNull] CommandDefinitionContext context)
        {
            string name = context.GetCommandNameText();
            CurrentFieldDefinitions = context.fieldDefinition();
            return new EntityObjectModel(name, ModelType.Command);
        }

        public override EntityObjectModel VisitDataTransferObjectDefinition([NotNull] DataTransferObjectDefinitionContext context)
        {
            string name = context.GetDataTransferObjectNameText();
            CurrentFieldDefinitions = context.fieldDefinition();
            return new EntityObjectModel(name, ModelType.DTO);
        }

        public override EntityObjectModel VisitEventDefinition([NotNull] EventDefinitionContext context)
        {
            string name = context.GetEventNameText();
            CurrentFieldDefinitions = context.fieldDefinition();
            return new EntityObjectModel(name, ModelType.Event);
        }
        public override EntityObjectModel VisitValueObjectDefinition([NotNull] ValueObjectDefinitionContext context)
        {
            string name = context.GetValueObjectNameText();
            CurrentFieldDefinitions = context.fieldDefinition();
            return new EntityObjectModel(name, ModelType.ValueObject);
        }

    }
}
