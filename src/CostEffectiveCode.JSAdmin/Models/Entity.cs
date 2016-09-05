namespace CostEffectiveCode.JSAdmin.Models
{
    public class Entity
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public bool ReadOnly { get; set; }

        public View CreationView { get; set; }

        public View EditionView { get; set; }

        public View DeletionView { get; set; }

        public View ShowView { get; set; }

        public View ListView { get; set; }
    }
}