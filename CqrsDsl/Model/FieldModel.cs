using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsDsl.Model
{
    public class FieldModel
    {
        public string PropertyName { get; private set; }
        public string TypeName { get; private set; }
        public bool IsOptional { get; private set; }
        public bool IsRequired { get; private set; }
        public bool IsPredefinedType { get; private set; }

        public FieldModel(
            string propertyName,
            string typeName,
            bool isOptional,
            bool isRequired,
            bool isPredefinedType)
        {
            PropertyName = propertyName;
            TypeName = typeName;
            IsOptional = isOptional;
            IsRequired = isRequired;
            IsPredefinedType = isPredefinedType;
        }
    }
}
