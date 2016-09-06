using System;
using System.ComponentModel.DataAnnotations;
using CostEffectiveCode.Ddd.Entities;

namespace CostEffectiveCode.WebApi2.Example2.Models
{
    public class Test: EntityBase<int>
    {
        [Required]
        public string Title { get; set; }

        public double Price { get; set; }

        public DateTime PublishDate { get; set; }

        public Info Info { get; set; }
    }

    public class Info
    {
        public string Name { get; set; }
    }
}