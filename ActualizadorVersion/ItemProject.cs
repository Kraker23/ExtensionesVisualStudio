using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualizadorVersion
{
    public class ItemProject
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Version { get; set; }
        private string getVersion { get { return !string.IsNullOrEmpty(Version) ? "(" + Version + ")" : string.Empty; } }
        public bool IsFolder { get; set; } = false;
        public List<ItemProject> ItemProjectosHijo { get; set; } = new List<ItemProject>();
        public override string ToString()
        {
            return $"{Name} {getVersion}";
        }
    }
}
