using GrillMaster.Infrastructure.BinPack.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Infrastructure.BinPack.Interfaces
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to create a Heuristic.
    /// </summary>
    public interface IHeuristicFactory
    {
        /// <summary>
        /// Create an instance of a Heuristic.
        /// </summary>
        IHeuristic Create(ERectangleHeuristic heuristic);
    }
}
