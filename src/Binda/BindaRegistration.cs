using System;

namespace Binda
{
    public class BindaRegistration
    {
        public BindaRegistration(string accessProperty, Type propertyType)
        {
            AccessProperty = accessProperty;
            PropertyType = propertyType;
        }

        public string AccessProperty { get; set; }
        public Type PropertyType { get; set; }
    }
}