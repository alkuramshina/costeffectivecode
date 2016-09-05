using System.Collections.Generic;

namespace CostEffectiveCode.JSAdmin.Models
{
    public class Application
    {
        public string Title { get; set; }

        public string BaseApiUrl { get; set; }

        public List<Entity> Entities { get; set; }
    }
}
