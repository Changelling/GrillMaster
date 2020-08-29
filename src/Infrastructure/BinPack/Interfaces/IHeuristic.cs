using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Infrastructure.BinPack.Interfaces
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to find the optimal position of an item in the Bin.
    /// </summary>
    public interface IHeuristic
    {
        /// <summary>
		/// Find the optimal position to store the element
		/// </summary>
        Task<Rectangle> FindPosition(IEnumerable<Rectangle> freeSpaces, bool allowFlip, int width, int height, params int[] scores);
    }
}
