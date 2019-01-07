using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Seldino.CrossCutting.Web.Extensions
{
    public static class EnumExtension
    {
        public static string DisplayEnumName(this Enum value)
        {
            try
            {
                Type enumType = value.GetType();

                var enumValue = Enum.GetName(enumType, value);

                MemberInfo member = enumType.GetMember(enumValue)[0];

                var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);

                var outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                {
                    outString = ((DisplayAttribute)attrs[0]).GetName();
                }

                return outString;
            }
            catch
            {
                return value.ToString();
            }
        }

        public static string GetDisplayName<TEnum>(this TEnum enumArg)
        {
            var fieldInfo = enumArg.GetType().GetField(enumArg.ToString());

            var attributes = (DisplayAttribute[])fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false);

            return attributes?.Length > 0
                ? attributes[0].Name
                : enumArg.ToString();
        }
    }
}
