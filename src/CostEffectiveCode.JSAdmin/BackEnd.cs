using System;
using System.Collections.Generic;
using System.Reflection;
using CostEffectiveCode.JSAdmin.Models;
using System.Linq;
using CostEffectiveCode.JSAdmin.Extensions;

namespace CostEffectiveCode.JSAdmin
{
    public class BackEnd
    {
        private readonly Assembly[] _assemblies;

        public BackEnd(string[] assemblies)
        {
            _assemblies = assemblies.Select(assemblyName => Assembly.Load(new AssemblyName(assemblyName)))
                .ToArray();
        }

        public Application Init(string title)
        {
            var application = new Application
            {
                Title = title,
                Entities = new List<Entity>()
            };

            // TODO: fix the 'where' spec for controllers / implementations of CqrsController?
            var controllers = _assemblies.SelectMany(
                a => a.GetTypes()
                    .Where(type => type.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            application.Entities
                .AddRange(controllers.Select(DefineEntity));

            return application;
        }

        public Entity DefineEntity(Type controller)
        {
            // TODO: check the DisplayAttribute value
            var name = controller.Name
                .Replace("Controller", "");

            var entity = new Entity
            {
                Name = name,
                Label = name,
                ReadOnly = false
            };

            var actions = controller
                .GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Where(
                    m =>
                        !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true)
                            .Any());

            entity.DefineListView(actions.Single(x => x.Name == "List"));
            entity.DefineEditionView(actions.Single(x => x.Name == "Get"));

            return entity;
        }

    }
}