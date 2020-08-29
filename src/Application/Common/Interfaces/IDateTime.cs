using System;

namespace GrillMaster.Application.Common.Interfaces
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to return the actual DateTime.
    /// </summary>
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
