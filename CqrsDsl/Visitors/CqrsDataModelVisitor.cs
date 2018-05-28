using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CqrsDsl.Builder;
using CqrsDsl.Generated;
using CqrsDsl.Model;

namespace CqrsDsl.Visitors
{
    public class CqrsDataModelVisitor : CqrsBaseVisitor<CqrsDataModel>
    {

        private CqrsDataModelBuilder builder;

        public CqrsDataModelVisitor()
        {
            builder = new CqrsDataModelBuilder();
        }

        public override CqrsDataModel VisitDictionary([NotNull] CqrsParser.DictionaryContext context)
        {
            var projectVisitor = new ProjectModelVisitor(builder);

            var projects = context.projectAssignment().Select(a => projectVisitor.Visit(a));

            return builder
                .WithProjects(projects)
                .Build();
        }
    }
}
