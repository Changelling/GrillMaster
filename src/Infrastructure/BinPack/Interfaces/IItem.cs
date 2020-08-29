using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GrillMaster.Infrastructure.BinPack.Interfaces
{
    /// <summary>
    /// Resumen:
    ///     Defines an item that can be packed.
    /// </summary>
    public interface IItem
    {
        public Rectangle Rectangle { get; set; }
    }
}
