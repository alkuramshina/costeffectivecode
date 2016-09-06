using System;
using System.Collections.Generic;
using System.Reflection;
using CostEffectiveCode.JSAdmin.Models;
using System.Linq;
using System.Web.Http;
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

        public Application Configure(string title)
        {
            var application = new Application
            {
                Title = title,
                Entities = new List<Entity>()
            };

            // TODO: implementations of CqrsController?
            var controllers = _assemblies.SelectMany(
                a => a.GetTypes()
                    .Where(type => type.IsClass && !type.IsAbstract
                                   && typeof(ApiController).IsAssignableFrom(type)));

            application.Entities
                .AddRange(controllers.Select(DefineEntity));

            return application;
        }

        public Entity DefineEntity(Type controller)
        {
            var name = controller.GetDisplayName();

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

            entity.DefineListView(actions);
            entity.DefineEditionView(actions);

            return entity;
        }
    }
}