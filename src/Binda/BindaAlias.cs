namespace Binda
{
    public class BindaAlias
    {
        public BindaAlias(string sourceProperty, string destinationAlias)
        {
            SourceProperty = sourceProperty;
            DestinationAlias = destinationAlias;
        }

        public string SourceProperty { get; set; }
        public string DestinationAlias { get; set; }
    }
}