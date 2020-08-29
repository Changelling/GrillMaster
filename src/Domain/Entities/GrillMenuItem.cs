using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Domain.Entities
{
    public class GrillMenuItem
    {
        public int sId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public TimeSpan Duration { get; set; }
        public int Quantity { get; set; }
    }
}
