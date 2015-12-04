using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fr.eCampusPlus.Engine.Model.POCO
{
    public class eCampusPlusPage
    {
        public string PageId { get; set; }

        public string Name { get; set; }

        public List<eCampusPlusWebElement> Fields { get; set; }
    }
}
