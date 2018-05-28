using System;
using System.Collections.Generic;
using System.Text;
using CqrsDsl.Model;

namespace CqrsDsl.Builder
{
    public class CqrsDataModelBuilder
    {
        #region current project model

        public ProjectModel CurrentProjectModel { get; private set; }
        private Dictionary<ProjectModel, ProjectModel> projectModelMaps = new Dictionary<ProjectModel, ProjectModel>();
        
        public ProjectModel GetOrCreateProjectModel(string projectName)
        {
            var projectModelToLookup = ModelFactory.CreateProjectModel(projectName);

            if (projectModelMaps.ContainsKey(projectModelToLookup))
            {
                return projectModelMaps[projectModelToLookup];
            }

            projectModelMaps.Add(projectModelToLookup, projectModelToLookup);

            return projectModelToLookup;
        }
        
        public CqrsDataModelBuilder SetCurrentProject(string projectName)
        {
            var currentProject = GetOrCreateProjectModel(projectName);
            CurrentProjectModel = currentProject;
            return this;
        }

        #endregion

        #region current namespace model

        public NamespaceModel CurrentNamespaceModel { get; private set; }
        private Dictionary<NamespaceModel, NamespaceModel> namespaceModelMaps = new Dictionary<NamespaceModel, NamespaceModel>();

        public NamespaceModel GetOrCreateNamespaceModel(ProjectModel projectModel, string namespaceName)
        {
            var namespaceModelToLookup = ModelFactory.CreateNamespaceModel(projectModel, namespaceName);

            if (namespaceModelMaps.ContainsKey(namespaceModelToLookup))
            {
                return namespaceModelMaps[namespaceModelToLookup];
            }

            namespaceModelMaps.Add(namespaceModelToLookup, namespaceModelToLookup);

            return namespaceModelToLookup;
        }

        public CqrsDataModelBuilder SetCurrentNamespace(string namespaceName)
        {
            var currentProject = GetOrCreateNamespaceModel(CurrentProjectModel, namespaceName);
            CurrentNamespaceModel = currentProject;
            return this;
        }

        #endregion

        #region builder

        private HashSet<ProjectModel> projects;
        private HashSet<NamespaceModel> namespaces;

        internal CqrsDataModelBuilder WithProjects(
            IEnumerable<ProjectModel> projects)
        {
            this.projects = new HashSet<ProjectModel>(projects);
            return this;
        }

        internal CqrsDataModelBuilder WithNamespaces(
            IEnumerable<NamespaceModel> namespaces)
        {
            this.namespaces = new HashSet<NamespaceModel>(namespaces);
            return this;
        }

        internal CqrsDataModel Build()
        {
            var model = new CqrsDataModel(
                projects,
                namespaces
                );
            return model;
        }

        #endregion
    }
}
