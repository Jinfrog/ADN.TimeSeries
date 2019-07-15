using ADN.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADN.TimeSeries
{
    /// <summary>
    /// Class that implements thresholding algorithm with robust average filter.
    /// </summary>
    public class RobustZScore : ZScore
    {
        protected override double ComputeAverage(List<double> values, int start, int end)
        {
            return values.Median(start, end);
        }
    }
}
