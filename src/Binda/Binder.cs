using System.Linq;

namespace Binda
{
    public class Binder
    {
        public static void Bind(object source, object destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();
            foreach (var destinationProperty in destinationProperties)
            {
                //Find matching property in source
                var sourceProperty = sourceProperties.FirstOrDefault(x => x.Name.ToUpper() == destinationProperty.Name.ToUpper());
                if (sourceProperty == null) continue;

                var value = sourceProperty.GetValue(source, null);
                destinationProperty.SetValue(destination, value, null);
            }
        }
    }
}