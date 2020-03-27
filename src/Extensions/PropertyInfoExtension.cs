using System.Reflection;

namespace PostgreSqlDotnetCore.Extensions
{
    public static class PropertyInfoExtension
    {
        public static string GetValueOrDefault(this PropertyInfo  propertyInfo,object obj)
        {
            var propValue = propertyInfo.GetValue(obj,null);
            if(propValue ==null)
                return "";
            return propValue.ToString();
        }

    }
}