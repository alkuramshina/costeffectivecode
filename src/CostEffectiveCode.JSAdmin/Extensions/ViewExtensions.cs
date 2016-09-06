using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http.Description;
using CostEffectiveCode.JSAdmin.Models;

namespace CostEffectiveCode.JSAdmin.Extensions
{
    public static class ViewExtensions
    {
        public static void DefineListView(this Entity entity, IEnumerable<MemberInfo> action)
        {
            if (!action.Any(act => act.Name.Equals("list", StringComparison.CurrentCultureIgnoreCase)))
                return;

            entity.ListView = new View {Title = "List"};
        }

        public static void DefineDeletionView(this Entity entity, IEnumerable<MemberInfo> action)
        {
            entity.DeletionView = new View {Title = "Deletion"};
        }

        public static void DefineEditionView(this Entity entity, IEnumerable<MemberInfo> action)
        {
            entity.EditionView = new View {Title = "Edition"};
        }

        public static void DefineCreationView(this Entity entity, IEnumerable<MemberInfo> action)
        {
            entity.CreationView = new View {Title = "Creation"};
        }

        private static Type GetResponseType(MemberInfo type)
        {
            var attr = type.GetCustomAttribute<ResponseTypeAttribute>();
            if (attr == null)
                throw new NotSupportedException();

            return attr.ResponseType;
        }
    }
}
