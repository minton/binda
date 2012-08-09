namespace Binda
{
    public class BindaAlias
    {
        /// <summary>
        /// Creates an alias for a destination property.
        /// </summary>
        /// <param name="property">Name of the property with an alias.</param>
        /// <param name="alias">The name of the alias.</param>
        public BindaAlias(string property, string alias)
        {
            Property = property;
            DestinationAlias = alias;
        }

        public string Property { get; private set; }
        public string DestinationAlias { get; private set; }
    }
}