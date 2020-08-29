using GrillMaster.Infrastructure.BinPack.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Infrastructure.BinPack.Interfaces
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to create a Bin.
    /// </summary>
    public interface IBinFactory
    {
        /// <summary>
        /// Create an instance of a Bin.
        /// </summary>
        IBin Create(EBinPackStrategy heuristic);
    }
}
