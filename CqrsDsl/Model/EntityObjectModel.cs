using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsDsl.Model
{
    public class EntityObjectModel
    {
        public string Name { get; }
        public ModelType Type { get; }

        public EntityObjectModel(string name, ModelType modelType)
        {
            Name = name;
            Type = modelType;
        }
    }
}
