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
            var fields = responseType.GetElementType()
                .GetJsFields();

            entity.ListView = new View { Title = "List", Fields = fields };
        }

        public static void DefineEditionView(this Entity entity, IEnumerable<MemberInfo> actions)
        {
            var action = actions.SingleOrDefault(act => act.Name
                .Equals("get", StringComparison.CurrentCultureIgnoreCase));

            if (action == null) return;

            var responseType = GetResponseType(action);
            var fields = responseType.GetJsFields();

            entity.EditionView = new View {Title = "Edition", Fields = fields };
        }

        public static void DefineDeletionView(this Entity entity, IEnumerable<MemberInfo> actions)
        {
            throw new NotImplementedException();
        }

        public static void DefineCreationView(this Entity entity, IEnumerable<MemberInfo> actions)
        {
            throw new NotImplementedException();
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
