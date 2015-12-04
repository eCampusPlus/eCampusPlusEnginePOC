using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.eCampusPlus.Engine.Model.POCO
{
    public class eCampusPlusPagesConfiguration
    {
        public string VertionNumber { get; set; }
        public List<eCampusPlusPlateformePages> Plateforme { get; set; } 
    }
}
