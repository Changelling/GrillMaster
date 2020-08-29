using GrillMaster.Infrastructure.BinPack.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Infrastructure.BinPack.Heuristic
{
	/// <summary>
	/// Implements the Bottom Left Heuristic.
	/// </summary>
	public class BottomLeftHeuristic : IHeuristic
    {
		public BottomLeftHeuristic() {
		}

		/// <summary>
		/// Find the optimal position (Bottom-Left) to store the element
		/// </summary>
		public async Task<Rectangle> FindPosition(IEnumerable<Rectangle> freeRectangles, bool allowFlip, int width, int height, params int[] scores)
        {
			Rectangle bestNode = new Rectangle();
			int bestY = int.MaxValue;
			int bestX = int.MaxValue;
            foreach (var rectangle in freeRectangles)
            {
				// Try to place the rectangle in upright (non-flipped) orientation.
				if (rectangle.Width >= width && rectangle.Height >= height)
				{
					int topSideY = rectangle.Y + height;
					if (topSideY < bestY || (topSideY == bestY && rectangle.X < bestX))
					{
						bestNode.X = rectangle.X;
						bestNode.Y = rectangle.Y;
						bestNode.Width = width;
						bestNode.Height = height;
						bestY = topSideY;
						bestX = rectangle.X;
					}
				}
				if (allowFlip && rectangle.Width >= height && rectangle.Height >= width)
				{
					int topSideY = rectangle.Y + width;
					if (topSideY < bestY || (topSideY == bestY && rectangle.X < bestX))
					{
						bestNode.X = rectangle.X;
						bestNode.Y = rectangle.Y;
						bestNode.Width = height;
						bestNode.Height = width;
						bestY = topSideY;
						bestX = rectangle.X;
					}
				}
			}
			return bestNode;
		}
    }
}
