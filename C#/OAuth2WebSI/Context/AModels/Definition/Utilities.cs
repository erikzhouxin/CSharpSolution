﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public static class Utilities
    {
        /// <summary>
        /// Ensures that local times are converted to UTC times.  Unspecified kinds are recast to UTC with no conversion.
        /// </summary>
        /// <param name="value">The date-time to convert.</param>
        /// <returns>The date-time in UTC time.</returns>
        public static DateTime AsUtc(this DateTime value)
        {
            if (value.Kind == DateTimeKind.Unspecified)
            {
                return new DateTime(value.Ticks, DateTimeKind.Utc);
            }
            return value.ToUniversalTime();
        }
    }
}