using GrillMaster.Infrastructure.BinPack.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Infrastructure.BinPack.Interfaces
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to create a collection of Bins.
    /// </summary>
    public interface IBinPack
    {
        /// <summary>
        /// (Re)initializes the packer to an bin of width x height units.
        /// </summary>
        void Init(int width, int height, bool allowFlip = true, bool ordered = true);

        /// <summary>
        /// Inserts the given list of items in an offline/batch mode, possibly rotated.
        /// </summary>
        Task<IEnumerable<IBin>> Pack(IEnumerable<IItem> items);
    }
}
