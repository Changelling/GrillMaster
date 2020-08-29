using GrillMaster.Infrastructure.BinPack.Enums;
using GrillMaster.Infrastructure.BinPack.Heuristic;
using GrillMaster.Infrastructure.BinPack.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GrillMaster.Infrastructure.BinPack
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to create a Heuristic.
    /// </summary>
    public class HeuristicFactory: IHeuristicFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public HeuristicFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Create an instance of a Heuristic.
        /// </summary>
        public IHeuristic Create(ERectangleHeuristic heuristic)
        {
            switch (heuristic)
            {
                case ERectangleHeuristic.RectBottomLeftRule:
                    return (IHeuristic)_serviceProvider.GetService(typeof(BottomLeftHeuristic));
                default:
                    break;
            }
            return null;
        }

    }
}
