using GrillMaster.Infrastructure.BinPack._2D;
using GrillMaster.Infrastructure.BinPack.Enums;
using GrillMaster.Infrastructure.BinPack.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Infrastructure.BinPack
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to create a Bin.
    /// </summary>
    public class BinFactory: IBinFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BinFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Create an instance of a Bin.
        /// </summary>
        public IBin Create(EBinPackStrategy binPackStrategy)
        {
            switch (binPackStrategy)
            {
                case EBinPackStrategy.MaxRect:
                    return (IBin)_serviceProvider.GetService(typeof(MaxRectsBinPack));                
                default:
                    break;
            }
            return null;
        }
    }
}
