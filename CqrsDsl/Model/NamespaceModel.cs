using System;
using System.Collections.Generic;
using System.Text;
using CqrsDsl.Abstract;

namespace CqrsDsl.Model
{
    public class NamespaceModel : ValueObject<NamespaceModel>
    {
        public ProjectModel ProjectModel { get; private set; }
        public string Name { get; private set; }

        public NamespaceModel(ProjectModel projectModel, string namespaceName)
        {
            ProjectModel = projectModel ?? throw new ArgumentNullException(nameof(projectModel));
            Name = namespaceName ?? throw new ArgumentNullException(nameof(namespaceName));
        }

        protected override bool EqualsCore(NamespaceModel other)
        {
            return other.ProjectModel == ProjectModel &&
                other.Name == Name;
        }

        protected override int GetHashCodeCore()
        {
            int hashCode = 17;

            hashCode = (hashCode * 23) + ProjectModel.GetHashCode();
            hashCode = (hashCode * 23) + Name.GetHashCode();

            return hashCode;
        }
    }
}
