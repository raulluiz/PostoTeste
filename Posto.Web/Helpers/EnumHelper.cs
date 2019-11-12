using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Posto.Web.Helpers
{
    public static class EnumHelper
    {
        public static string GetName(Enum value)
        {
            if (value == null) return null;

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null) throw new ValidationException("Não foi possível reconhecer a opção " + value + " como um Enum válido");

            return ((DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false))[0].Name;
        }

        public static string GetDescription(Enum value)
        {
            if (value == null) return null;

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null) throw new ValidationException("Não foi possível reconhecer a opção " + value + " como um Enum válido");

            return ((DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
        }

        public static T GetAttribute<T>(Enum enumValue) where T : Attribute
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                var attribute = (T)memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                return attribute;
            }
            return null;
        }

        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new ValidationException("T must be an Enumeration type.");
            }

            return Enum.TryParse<T>(str, true, out var val) ? val : default(T);
        }

        public static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new ValidationException("T must be an Enumeration type.");
            }

            return (T)Enum.ToObject(enumType, intValue);
        }
    }
}
