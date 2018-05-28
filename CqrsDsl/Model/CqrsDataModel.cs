using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsDsl.Model
{
    public class CqrsDataModel
    {
        public IReadOnlyCollection<ProjectModel> Projects { get; private set; }
        public IReadOnlyCollection<NamespaceModel> Namespaces { get; private set; }
        public IReadOnlyCollection<EntityObjectModel> EntityObjects { get; private set; }

        public CqrsDataModel(
            IEnumerable<ProjectModel> projectModels,
            IEnumerable<NamespaceModel> namespaceModels,
            IEnumerable<EntityObjectModel> entityObjectModels)
        {
            Projects = new List<ProjectModel>(projectModels).AsReadOnly();
            Namespaces = new List<NamespaceModel>(namespaceModels).AsReadOnly();
            EntityObjects = new List<EntityObjectModel>(entityObjectModels).AsReadOnly();
        }
    }
}
