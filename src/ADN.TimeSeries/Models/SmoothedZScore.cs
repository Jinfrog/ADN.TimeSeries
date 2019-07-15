using ADN.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADN.TimeSeries
{
    /// <summary>
    /// Class that implements thresholding algorithm with smoothed average filter.
    /// </summary>
    public class SmoothedZScore : ZScore
    {
        protected override double ComputeAverage(List<double> values, int start, int end)
        {
            return values.Mean(start, end);
        }
    }
}
