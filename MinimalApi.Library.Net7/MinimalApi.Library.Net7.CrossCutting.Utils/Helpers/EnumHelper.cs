using System.ComponentModel;

namespace MinimalApi.Library.Net7.CrossCutting.Utils.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example><![CDATA[string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;]]></example>
        public static T? GetAttributeOfType<T>(Enum enumVal) where T : System.Attribute
        {

            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length == 0 ? null : (T)attributes[0];
        }

        public static string GetDescription(this Enum enumVal)
        {
            var attribute = GetAttributeOfType<DescriptionAttribute>(enumVal);
            return attribute is not null ? attribute.Description : "Failed to get error description";
        }
    }
}
