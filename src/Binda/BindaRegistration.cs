using System;

namespace Binda
{
    internal class BindaRegistration
    {
        public BindaRegistration(string property, Type type)
        {
            AccessProperty = property;
            PropertyType = type;
        }

        public string AccessProperty { get; private set; }
        public Type PropertyType { get; private set; }
    }
}