using System.Reflection;
using CometX.NETCore.Attributes.RelationalDBAttributes;

namespace CometX.NETCore.Attributes.Extensions.RelationalDBExtensions
{
    public static class RelationalDBExtensions
    {
        public static bool HasAllowIdentityUpdateAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<AllowIdentityColumnUpdateAttribute>() != null;

        public static bool HasAttributeRestrictions(this PropertyInfo propertyInfo) => propertyInfo.HasPropertyNotMappedAttribute() || (propertyInfo.HasPrimaryKeyAttribute() && !propertyInfo.HasAllowIdentityUpdateAttribute());
        public static bool HasColumnNotMappedAttribute(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<ColumnNotMappedAttribute>() != null;
        }

        public static bool HasDbColumnAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<DBColumnAttribute>() != null;

        public static bool HasPrimaryKeyAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<PrimaryKeyAttribute>() != null;

        public static bool HasPropertyNotMappedAttribute(this PropertyInfo propertyInfo) => propertyInfo.GetCustomAttribute<PropertyNotMappedAttribute>() != null;

        public static string GetDbColumnAttributeMapping(this PropertyInfo propertyInfo)
        {
            string name = "";

            var columnMapping = propertyInfo.GetCustomAttribute<DBColumnAttribute>();

            if (columnMapping != null) name = (columnMapping as DBColumnAttribute).Name;

            return name;
        }
    }
}
