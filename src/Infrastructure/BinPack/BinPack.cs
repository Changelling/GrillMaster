using GrillMaster.Infrastructure.BinPack.Enums;
using GrillMaster.Infrastructure.BinPack.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillMaster.Infrastructure.BinPack
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to create a collection of Bins.
    /// </summary>
    public class BinPack : IBinPack
    {
        private readonly IBinFactory _binFactory; 
        private readonly IHeuristicFactory _heuristicFactory;
        private readonly EBinPackStrategy _packStrategy;
        private readonly ERectangleHeuristic _rectangleHeuristic;
        private readonly List<IBin> _bins;
        private Size _dimension;
        private bool _allowFlip;
        private bool _ordered;

        public BinPack(IBinFactory binFactory, IHeuristicFactory heuristicFactory, 
            EBinPackStrategy packStrategy, ERectangleHeuristic rectangleHeuristic)
        {
            _binFactory = binFactory;
            _heuristicFactory = heuristicFactory;
            _packStrategy = packStrategy;
            _rectangleHeuristic = rectangleHeuristic;            
            _bins = new List<IBin>();
            
        }

        /// <summary>
        /// (Re)initializes the packer to an bin of width x height units.
        /// </summary>
        public void Init(int width, int height, bool allowFlip = true, bool ordered = true)
        {
            _bins.Clear();
            _dimension = new Size(width, height);
            _allowFlip = allowFlip;
            _ordered = ordered;
            AddBin();
        }

        private void AddBin()
        {
            IBin bin = _binFactory.Create(_packStrategy);
            bin.Init(_dimension.Width, _dimension.Height, _allowFlip);
            IHeuristic heuristic = _heuristicFactory.Create(_rectangleHeuristic);
            bin.SetHeuristic(heuristic);
            _bins.Add(bin);
        }

        /// <summary>
        /// Inserts the given list of items in an offline/batch mode, possibly rotated.
        /// </summary>
        public async Task<IEnumerable<IBin>> Pack(IEnumerable<IItem> items)
        {
            if (_ordered)
                items = items.OrderByDescending(i => i.Rectangle.Width * i.Rectangle.Height);
            foreach (var item in items)
            {
                await Pack(item);
            }
            return _bins;
        }

        private async Task Pack(IItem item)
        {
            int i = 0;
            bool hasPacked = false;
            int actualSize = _bins.Count;
            while (!hasPacked && i < actualSize + 1)
            {
                IBin bin = _bins[i++];
                hasPacked = await bin.Pack(item);
                if (!hasPacked && i == actualSize)
                {
                    AddBin();
                }
            }
        }
    }
}
