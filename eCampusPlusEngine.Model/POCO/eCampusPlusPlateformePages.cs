using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fr.eCampusPlus.Engine.Model.POCO
{
    public class eCampusPlusPlateformePages
    {
        public string PlateformeId { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public List<eCampusPlusPage> Pages { get; set; } 
    }
}
