// UWPReflectionExtensions|Utilities|90100
namespace VRTK
{
#if UNITY_WSA && !UNITY_EDITOR
    using System.Reflection;
    using System.Collections.Generic;

    public static class UWPReflectionExtensions
    {
        public static object[] GetCustomAttributes(this System.Type type, System.Type inputType, bool state)
        {
            return (object[])type.GetTypeInfo().GetCustomAttributes(inputType, false);
        }

        public static System.Type GetNestedType(this System.Type type, string nestedType)
        {
            return type.GetTypeInfo().GetDeclaredNestedType(nestedType).GetType();
        }

        public static bool IsSubclassOf(this System.Type type, System.Type baseClassType)
        {
            return type.GetTypeInfo().IsSubclassOf(baseClassType);
        }
    
        public static bool IsAssignableFrom(this System.Type type, System.Type baseClassType)
        {
            return type.GetTypeInfo().IsSubclassOf(baseClassType);
        }

        public static IEnumerable<PropertyInfo> GetProperties(this System.Type type)
        {
            return type.GetTypeInfo().DeclaredProperties;
        }
    }
#endif
}