using System.Reflection;
using CostEffectiveCode.JSAdmin.Models;

namespace CostEffectiveCode.JSAdmin.Extensions
{
    public static class ViewExtensions
    {
        public static void DefineListView(this Entity entity, MemberInfo action)
        {
            entity.ListView = new View {Title = "List"};
        }

        public static void DefineDeletionView(this Entity entity, MemberInfo action)
        {
            entity.DeletionView = new View {Title = "Deletion"};
        }

        public static void DefineEditionView(this Entity entity, MemberInfo action)
        {
            entity.EditionView = new View {Title = "Edition"};
        }

        public static void DefineCreationView(this Entity entity, MemberInfo action)
        {
            entity.CreationView = new View {Title = "Creation"};
        }
    }
}
