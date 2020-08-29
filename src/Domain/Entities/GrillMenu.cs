using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Domain.Entities
{
    public class GrillMenu
    {
        public GrillMenu()
        {
            Items = new List<GrillMenuItem>();
        }

        public int sId { get; set; }
        public string Id { get; set; }

        public string Menu { get; set; }        

        public IList<GrillMenuItem> Items { get; set; }
    }
}
