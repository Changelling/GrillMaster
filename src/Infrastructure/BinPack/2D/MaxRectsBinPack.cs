using GrillMaster.Infrastructure.BinPack.Enums;
using GrillMaster.Infrastructure.BinPack.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Infrastructure.BinPack._2D
{

    /// <summary>
    /// Implements the MAXRECTS data structure and different bin packing algorithms that use this structure.
    /// </summary>
    public class MaxRectsBinPack : IBin
    {
        private IHeuristic _heuristic;
        private readonly IHeuristicFactory _heuristicFactory;

        public MaxRectsBinPack(IHeuristicFactory heuristicFactory)
        {
            _heuristicFactory = heuristicFactory;
        }

        public Size Dimensions { get; protected set; }
        public bool AllowFlip { get; protected set; }
        public List<IItem> UsedSpaces { get; protected set; }
        public List<Rectangle> FreeSpaces { get; protected set; }

        /// <summary>
        /// (Re)initializes the packer to an empty bin of width x height units.
        /// </summary>
        public void Init(int Width, int Height, bool allowFlip = true)
        {
            this.AllowFlip = allowFlip;
            this.Dimensions = new Size(Width, Height);
            UsedSpaces = new List<IItem>();
            FreeSpaces = new List<Rectangle>();
            Point defaultPosition = new Point(0, 0);
            Rectangle rectangle = new Rectangle(defaultPosition, Dimensions);
            FreeSpaces.Add(rectangle);
        }

        /// <summary>
        /// Establish the heuristic strategy to use.
        /// </summary>
        public void SetHeuristic(IHeuristic heuristic)
        {
            _heuristic = heuristic;
        }

        /// <summary>
        /// Inserts the given item in an offline/batch mode, possibly rotated.
        /// </summary>
        public async Task<bool> Pack(IItem item)
        {
            Rectangle packedRectangle = await _heuristic.FindPosition(FreeSpaces, AllowFlip,
                item.Rectangle.Width, item.Rectangle.Height);
            if (packedRectangle.Height <= 0)
                return false;
            int numRectanglesToProcess = FreeSpaces.Count;
            for (int i = 0; i < numRectanglesToProcess; ++i)
            {
                if (await SplitFreeNode(FreeSpaces[i], packedRectangle))
                {
                    FreeSpaces.RemoveAt(i--);
                    --numRectanglesToProcess;
                }
            }
            await PruneFreeList();
            item.Rectangle = packedRectangle;
            UsedSpaces.Add(item);
            return packedRectangle.Height > 0;
        }

        /// <summary>
        /// Return True if the free node was split.
        /// </summary>
        private async Task<bool> SplitFreeNode(Rectangle freeRectangle, Rectangle usedNode)
        {
            // Test with SAT if the rectangles even intersect.
            if (usedNode.X >= freeRectangle.X + freeRectangle.Width || usedNode.X + usedNode.Width <= freeRectangle.X ||
                usedNode.Y >= freeRectangle.Y + freeRectangle.Height || usedNode.Y + usedNode.Height <= freeRectangle.Y)
                return false;

            if (usedNode.X < freeRectangle.X + freeRectangle.Width && usedNode.X + usedNode.Width > freeRectangle.X)
            {
                // New node at the top side of the used node.
                if (usedNode.Y > freeRectangle.Y && usedNode.Y < freeRectangle.Y + freeRectangle.Height)
                {
                    Rectangle newNode = freeRectangle;
                    newNode.Height = usedNode.Y - newNode.Y;
                    FreeSpaces.Add(newNode);
                }

                // New node at the bottom side of the used node.
                if (usedNode.Y + usedNode.Height < freeRectangle.Y + freeRectangle.Height)
                {
                    Rectangle newNode = freeRectangle;
                    newNode.Y = usedNode.Y + usedNode.Height;
                    newNode.Height = freeRectangle.Y + freeRectangle.Height - (usedNode.Y + usedNode.Height);
                    FreeSpaces.Add(newNode);
                }
            }

            if (usedNode.Y < freeRectangle.Y + freeRectangle.Height && usedNode.Y + usedNode.Height > freeRectangle.Y)
            {
                // New node at the left side of the used node.
                if (usedNode.X > freeRectangle.X && usedNode.X < freeRectangle.X + freeRectangle.Width)
                {
                    Rectangle newNode = freeRectangle;
                    newNode.Width = usedNode.X - newNode.X;
                    FreeSpaces.Add(newNode);
                }

                // New node at the right side of the used node.
                if (usedNode.X + usedNode.Width < freeRectangle.X + freeRectangle.Width)
                {
                    Rectangle newNode = freeRectangle;
                    newNode.X = usedNode.X + usedNode.Width;
                    newNode.Width = freeRectangle.X + freeRectangle.Width - (usedNode.X + usedNode.Width);
                    FreeSpaces.Add(newNode);
                }
            }

            return true;
        }

        /// <summary>
        /// Goes through the free rectangle list and removes any redundant entries.
        /// </summary>
        private async Task PruneFreeList()
        {
            for (int i = 0; i < FreeSpaces.Count; ++i)
                for (int j = i + 1; j < FreeSpaces.Count; ++j)
                {
                    if (FreeSpaces[j].Contains(FreeSpaces[i]))
                    {
                        FreeSpaces.RemoveAt(i);
                        --i;
                        break;
                    }
                    if (FreeSpaces[i].Contains(FreeSpaces[j]))
                    {
                        FreeSpaces.RemoveAt(j);
                        --j;
                    }
                }
        }
    }
}
