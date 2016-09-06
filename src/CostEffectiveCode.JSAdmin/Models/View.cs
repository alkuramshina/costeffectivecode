using System.Collections.Generic;

namespace CostEffectiveCode.JSAdmin.Models
{
    public class View
    {
        public string Title { get; set; }

        public IEnumerable<Field> Fields { get; set; }
    }
}