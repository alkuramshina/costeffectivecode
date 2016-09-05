using CostEffectiveCode.Ddd.Entities;

namespace CostEffectiveCode.WebApi2.Example2.Models
{
    public class TestDto : EntityBase<int>
    {
        public string Name { get; set; }
    }
}