using CostEffectiveCode.Ddd.Entities;

namespace CostEffectiveCode.WebApi2.Example2.Models
{
    public class Test: EntityBase<int>
    {
        public Info Info { get; set; }
    }

    public class Info
    {
        public string Name { get; set; }
    }
}