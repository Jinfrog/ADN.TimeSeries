using ADN.Helpers.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADN.TimeSeries
{
    /// <summary>
    /// Class that implements thresholding algorithm.
    /// </summary>
    public class SmoothedZScore
    {
        private List<double> _filteredY = new List<double>();
        private List<double> _avgFilter = new List<double>();
        private List<double> _stdFilter = new List<double>();

        private double _threshold = 0;
        private double _influence = 0;
        private int _lag = 10;

        /// <summary>
        /// Set the threshold. The z-score at which the algorithm signals.
        /// </summary>
        /// <param name="threshold">Value to signal if a datapoint is out of standard deviations away from the moving mean.</param>
        /// <exception cref="ArgumentException">threshold must be positive</exception>
        public void SetThreshold(double threshold)
        {
            // Check arguments
            if (threshold < 0)
            {
                throw (new ArgumentException("threshold must be positive"));
            }

            _threshold = threshold;
        }

        /// <summary>
        /// Set the influence.
        /// </summary>
        /// <param name="influence">The influence (between 0 and 1) of new signals on the mean and standard deviation.</param>
        /// <exception cref="ArgumentException">influence must to be between 0 and 1</exception>
        public void SetInfluence(double influence)
        {
            // Check arguments
            if (influence < 0 || influence > 1)
            {
                throw (new ArgumentException("influence must to be between 0 and 1"));
            }

            _influence = influence;
        }

        /// <summary>
        /// Set the lag.
        /// </summary>
        /// <param name="lag">The lag of the moving window.</param>
        /// <exception cref="ArgumentException">lag must be strictly positive</exception>
        public void SetLag(int lag)
        {
            // Check arguments
            if (lag <= 0)
            {
                throw (new ArgumentException("lag must be strictly positive"));
            }

            _lag = lag;
        }

        /// <summary>
        /// Add a new point.
        /// </summary>
        /// <param name="value">New point.</param>
        /// <returns>Signal detected: 1 if positive signal, -1 if negative signal and 0 otherwise.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var smoothedZScore = new SmoothedZScore();
        /// double[] points = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, -5 };
        /// 
        /// <![CDATA[for (int i = 0; i < points.Length; i++)]]>
        /// {
        ///     double detectedValue = smoothedZScore.Add(value[i]);
        /// 
        ///     if (detectedValue == 1) Console.WriteLine("Detected raise flank");
        ///     else if (detectedValue == -1) Console.WriteLine("Detected falling flank");
        /// }
        /// </code>
        /// </example>
        public int Add(double value)
        {
            int signal = 0;
            int i = _filteredY.Count;


            if (i > _lag)
            {
                if (Math.Abs(value - _avgFilter[i - 1]) > _threshold * _stdFilter[i - 1])
                {
                    signal = (value > _avgFilter[i - 1]) ? 1 : -1;

                    //Make influence lower
                    _filteredY.Add(_influence * value + (1 - _influence) * _filteredY[i - 1]);
                }
                else
                {
                    _filteredY.Add(value);
                }

                //Adjust the filters
                _avgFilter.Add(_filteredY.Mean(i - _lag, i));
                _stdFilter.Add(_filteredY.StandardDeviation(i - _lag, i));

                // remove unused elements
                _filteredY.RemoveAt(0);
                _avgFilter.RemoveAt(0);
                _stdFilter.RemoveAt(0);
            }
            else
            {
                _filteredY.Add(value);

                //Adjust the filters
                _avgFilter.Add(_filteredY.Mean(0, i));
                _stdFilter.Add(_filteredY.StandardDeviation(0, i));
            }

            return signal;
        }
    }
}
