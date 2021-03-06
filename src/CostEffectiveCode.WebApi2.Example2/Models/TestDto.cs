using System;
using System.ComponentModel.DataAnnotations;
using CostEffectiveCode.Ddd.Entities;

namespace CostEffectiveCode.WebApi2.Example2.Models
{
    public class TestDto : EntityBase<int>
    {
        [Required]
        public string Title { get; set; }

        public double Price { get; set; }

        public DateTime PublishDate { get; set; }

        public InfoDto Info { get; set; }
    }

    public class InfoDto 
    {
        public string Name { get; set; }
    }
}