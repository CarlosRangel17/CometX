using System.Reflection;
using CometX.NETCore.Attributes;

namespace CometX.NETCore.Extensions.PropertyAttributes
{
    public static class PropertyExtensions
    {
        public static bool HasFlagAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<FlagAttribute>() != null;

        public static bool HasIsActiveAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<IsActiveAttribute>() != null;
    }
}
