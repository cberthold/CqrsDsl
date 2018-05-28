using System;
using System.Collections.Generic;
using System.Text;
using CqrsDsl.Model;

namespace CqrsDsl.Builder
{
    public class ModelFactory
    {
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
    }
}
