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
    ///     Provides a mechanism for packaging an item in a Bin.
    /// </summary>
    public interface IBin
    {
        Size Dimensions { get;}
        bool AllowFlip { get;}
        List<IItem> UsedSpaces { get;}
        List<Rectangle> FreeSpaces { get;}

        /// <summary>
        /// (Re)initializes the packer to an empty bin of width x height units.
        /// </summary>
        void Init(int width, int height, bool allowFlip);

        /// <summary>
        /// Establish the heuristic strategy to use.
        /// </summary>
        void SetHeuristic(IHeuristic heuristic);

        /// <summary>
        /// Inserts the given item in an offline/batch mode, possibly rotated.
        /// </summary>
        Task<bool> Pack(IItem item);
    }
}
