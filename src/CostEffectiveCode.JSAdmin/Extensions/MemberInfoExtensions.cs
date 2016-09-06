using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CostEffectiveCode.JSAdmin.Models;

namespace CostEffectiveCode.JSAdmin.Extensions
{
    public static class MemberInfoExtensions
    {
        public static string GetDisplayName(this MemberInfo type)
        {
            return type.GetCustomAttribute<DisplayAttribute>()?.GetName() ??
                   type.Name.Replace("Controller", "");
        }

        public static string GetInputType(this PropertyInfo type)
        {
            if (type.PropertyType == typeof(int)) return "number";
            if (type.PropertyType == typeof(float) || type.PropertyType == typeof(double)) return "float";
            if (type.PropertyType == typeof(bool)) return "boolean";
            if (type.PropertyType == typeof(DateTime)) return "date";

            if (type.PropertyType.IsClass)
                return "";

            if (type.GetCustomAttribute<EmailAddressAttribute>() != null)
                return "email";

            var dataType = type.GetCustomAttribute<DataTypeAttribute>();
            if (dataType != null)
            {
                switch (dataType.DataType)
                {
                    case DataType.Password:
                        return "password";
                    case DataType.EmailAddress:
                        return "email";
                    case DataType.MultilineText:
                        return "text";
                }
            }

            return "string";
        }

        public static Field ToJsField(this PropertyInfo type)
        {
            var field = new Field
            {
                Name = type.Name,
                Label = type.GetDisplayName(),
                Type = type.GetInputType(),
                Validation = new Validation { Required = type.GetCustomAttribute<RequiredAttribute>() != null }
            };

            return field;
        }
    }
}
