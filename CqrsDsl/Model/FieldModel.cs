using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsDsl.Model
{
    public class FieldModel
    {
        public string PropertyName { get; private set; }

        public FieldModel(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
