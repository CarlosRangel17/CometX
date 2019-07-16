using System.Reflection;

namespace CometX.Attributes.Extensions.PropertyExtensions
{
    public static class PropertyExtensions
    {
        public static bool HasFlagAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<FlagAttribute>() != null;

        public static bool HasIsActiveAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<IsActiveAttribute>() != null;
    }
}
