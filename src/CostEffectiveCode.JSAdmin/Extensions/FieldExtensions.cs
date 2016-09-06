using System;
using System.Collections.Generic;
using System.Linq;
using CostEffectiveCode.JSAdmin.Models;

namespace CostEffectiveCode.JSAdmin.Extensions
{
    public static class FieldExtensions
    {
        public static IEnumerable<Field> GetJsFields(this Type type)
        {
            return type.GetProperties()
                .Select(t => t.ToJsField());
        }
    }
}
