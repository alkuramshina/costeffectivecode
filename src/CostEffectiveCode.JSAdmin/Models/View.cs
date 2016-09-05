using System.Collections.Generic;

namespace CostEffectiveCode.JSAdmin.Models
{
    public class View
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string SortField { get; set; }

        public string SortDir { get; set; }

        public IEnumerable<Field> Fields { get; set; }
    }
}