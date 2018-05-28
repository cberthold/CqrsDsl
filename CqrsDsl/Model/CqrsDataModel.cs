using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsDsl.Model
{
    public class CqrsDataModel
    {
        public IReadOnlyCollection<ProjectModel> Projects { get; private set; }
        public IReadOnlyCollection<NamespaceModel> Namespaces { get; private set; }


        public CqrsDataModel(
            IEnumerable<ProjectModel> projectModels,
            IEnumerable<NamespaceModel> namespaceModels)
        {
            Projects = new List<ProjectModel>(projectModels).AsReadOnly();
            Namespaces = new List<NamespaceModel>(namespaceModels).AsReadOnly();
        }
    }
}
