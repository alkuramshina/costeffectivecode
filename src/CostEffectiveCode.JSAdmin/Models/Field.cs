using System.Collections.Generic;

namespace CostEffectiveCode.JSAdmin.Models
{
    public class Field
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public string Type { get; set; }

        public bool Editable { get; set; }

        public string Format { get; set; }

        public List<KeyValuePair<object, string>> Choices { get; set; }

        public Validation Validation { get; set; }
    }

    public class Validation
    {
        public bool Required { get; set; }

        public string Pattern { get; set; }
    }
}