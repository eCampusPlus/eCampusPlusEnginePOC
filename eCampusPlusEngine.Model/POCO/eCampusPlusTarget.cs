using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fr.eCampusPlus.Engine.Model.POCO
{
    public class eCampusPlusTarget
    {
        public string TargetId { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public List<eCampusPlusTargetDataAccess> Accesses { get; set; } 
    }
}
