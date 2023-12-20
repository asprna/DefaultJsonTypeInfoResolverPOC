using System.Text.Json.Serialization.Metadata;
using System.Text.Json;

namespace DefaultJsonTypeInfoResolverPOC
{
    public sealed class CustomJsonTypeInfoResolver : DefaultJsonTypeInfoResolver
    {
        public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            var typeInfo = base.GetTypeInfo(type, options);

            if (type.IsClass)
            {
                var propertiesToExclude = typeInfo.Properties.Where(o =>
                    o.AttributeProvider?.GetCustomAttributes(false)?.Any(o => o is ConditionallyExcludedAttribute) ?? false
                    ).ToList();

                propertiesToExclude.ForEach(o => o.ShouldSerialize = (_, _) => false);

                // Or remove the property.
                // propertiesToExclude.ForEach(o => typeInfo.Properties.Remove(o));
            }

            return typeInfo;
        }
    }
}
