using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using CqrsDsl.Generated;
using CqrsDsl.Model;

namespace CqrsDsl.Visitors
{
    public class EntityObjectModelVisitor : CqrsBaseVisitor<EntityObjectModel>
    {
        public override EntityObjectModel VisitCommandDefinition([NotNull] CqrsParser.CommandDefinitionContext context)
        {
            string name = context.GetCommandNameText();
            return new EntityObjectModel(name, ModelType.Command);
        }
        
        public override EntityObjectModel VisitDataTransferObjectDefinition([NotNull] CqrsParser.DataTransferObjectDefinitionContext context)
        {
            string name = context.GetDataTransferObjectNameText();
            return new EntityObjectModel(name, ModelType.DTO);
        }

        public override EntityObjectModel VisitEventDefinition([NotNull] CqrsParser.EventDefinitionContext context)
        {
            string name = context.GetEventNameText();
            return new EntityObjectModel(name, ModelType.Event);
        }
        public override EntityObjectModel VisitValueObjectDefinition([NotNull] CqrsParser.ValueObjectDefinitionContext context)
        {
            string name = context.GetValueObjectNameText();
            return new EntityObjectModel(name, ModelType.ValueObject);
        }

    }
}
