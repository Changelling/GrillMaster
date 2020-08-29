using GrillMaster.Application.Common.Interfaces;
using System;

namespace GrillMaster.Infrastructure.Services
{
    /// <summary>
    /// Resumen:
    ///     Provides a mechanism to return the actual DateTime.
    /// </summary>
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
