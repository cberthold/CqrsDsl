using System;
using System.Collections.Generic;
using System.Text;
using CqrsDsl.Abstract;

namespace CqrsDsl.Model
{
    public class ProjectModel : ValueObject<ProjectModel>
    {
        public string Name { get; private set; }

        public ProjectModel(string projectName)
        {
            Name = projectName ?? throw new ArgumentNullException(nameof(projectName));
        }

        protected override bool EqualsCore(ProjectModel other)
        {
            return other.Name == Name;
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }
    }
}
