using System;
using System.Collections.Generic;
using System.Text;
using CqrsDsl.Model;

namespace CqrsDsl.Builder
{
    public class ModelFactory
    {
        public static CqrsDataModel CreateCqrsDataModel(
            IEnumerable<ProjectModel> projects,
            IEnumerable<NamespaceModel> namespaces,
            IEnumerable<EntityObjectModel> entities
            )
        {
            var model = new CqrsDataModel(
                projects,
                namespaces,
                entities
                );
            return model;
        }

        public static ProjectModel CreateProjectModel(string projectName)
        {
            var model = new ProjectModel(projectName);
            return model;
        }

        public static NamespaceModel CreateNamespaceModel(ProjectModel projectModel, string namespaceName)
        {
            var model = new NamespaceModel(projectModel, namespaceName);
            return model;
        }

        public static FieldModel CreateFieldModel(string propertyName, string typeName, bool isOptional, bool isRequired, bool isPredefinedType)
        {
            return new FieldModel(
                propertyName, 
                typeName,
                isOptional,
                isRequired,
                isPredefinedType);
        }
    }
}
