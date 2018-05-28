using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CqrsDsl.Model
{
    public class EntityObjectModel
    {
        public string Name { get; }
        public ModelType Type { get; }
        public IReadOnlyCollection<FieldModel> Fields { get; }

        public EntityObjectModel(string name, ModelType modelType)
            : this(name, modelType, Enumerable.Empty<FieldModel>())
        {
        }

        private EntityObjectModel(string name, ModelType modelType, IEnumerable<FieldModel> fields)
        {
            Name = name;
            Type = modelType;
            Fields = new List<FieldModel>(fields).AsReadOnly();
        }

        public EntityObjectModel WithFields(IEnumerable<FieldModel> fields)
        {
            var model = new EntityObjectModel(Name, Type, fields);
            return model;
        }
    }
}
