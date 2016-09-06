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
        public static void DefineListView(this Entity entity, IEnumerable<MemberInfo> actions)
        {
            var action = actions.SingleOrDefault(act => act.Name
                .Equals("list", StringComparison.CurrentCultureIgnoreCase));

            if (action == null) return;

            var responseType = GetResponseType(action);

            entity.ListView = new View {Title = "List"};
        }

        public static void DefineDeletionView(this Entity entity, IEnumerable<MemberInfo> actions)
        {
            entity.DeletionView = new View {Title = "Deletion"};
        }

        public static void DefineEditionView(this Entity entity, IEnumerable<MemberInfo> actions)
        {
            var action = actions.SingleOrDefault(act => act.Name
                .Equals("get", StringComparison.CurrentCultureIgnoreCase));

            if (action == null) return;

            var responseType = GetResponseType(action);

            entity.EditionView = new View {Title = "Edition"};
        }

        public static void DefineCreationView(this Entity entity, IEnumerable<MemberInfo> actions)
        {
            entity.CreationView = new View {Title = "Creation"};
        }

        private static Type GetResponseType(MemberInfo type)
        {
            var attr = type.GetCustomAttribute<ResponseTypeAttribute>();
            if (attr == null)
                throw new NotSupportedException($"{type.Name} is required to have a ResponseTypeAttribute.");

            return attr.ResponseType;
        }
    }
}
