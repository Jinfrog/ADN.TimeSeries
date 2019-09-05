using System;
using System.Collections.Generic;
using System.Text;

namespace ADN.TimeSeries
{
    /// <summary>
    /// Class to calculate the Dynamic Time Wrapping.
    /// </summary>
    public class DTW
    {
        private double[] _x;
        private double[] _y;
        private readonly double[,] _distance;
        private readonly double[,] _f;
        private readonly double _sum;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="x">The first <see cref="Array"/> that contains data to calculate the DTW.</param>
        /// <param name="y">The second <see cref="Array"/> that contains data to calculate the DTW.</param>
        /// <param name="sakoeChibaBand">Size of limits to warping path of first <see cref="Array"/> to be inside the second <see cref="Array"/>.</param>
        /// <exception cref="ArgumentNullException">x is null</exception>
        /// <exception cref="ArgumentNullException">y is null</exception>
        /// <example>
        /// <code lang="csharp">
        /// var serie1= new double[] { 0, 1, 2, 3, 4, 5 };
        /// var serie2 = new double[] { 5, 4, 3, 2, 1, 0 };
        /// int sakoeChibaBand = -1;
        /// var dtw = new DTW(serie1, serie2, sakoeChibaBand);
        /// </code>
        /// </example>
        public DTW(double[] x, double[] y, int sakoeChibaBand = -1)
        {
            // Check arguments
            if (x is null || x.Length <= 0)
            {
                throw (new ArgumentNullException("x"));
            }

            if (y is null || y.Length <= 0)
            {
                throw (new ArgumentNullException("y"));
            }

            _x = x;
            _y = y;
            _distance = new double[x.Length, y.Length];
            _f = new double[x.Length + 1, y.Length + 1];

            for (int i = 0; i < x.Length; ++i)
            {
                for (int j = 0; j < y.Length; ++j)
                {
                    _distance[i, j] = Math.Abs(x[i] - y[j]);
                }
            }

            for (int i = 0; i <= x.Length; ++i)
            {
                for (int j = 0; j <= y.Length; ++j)
                {
                    _f[i, j] = -1;
                }
            }

            for (int i = 1; i <= x.Length; ++i)
            {
                _f[i, 0] = int.MaxValue;
            }
            for (int j = 1; j <= y.Length; ++j)
            {
                _f[0, j] = int.MaxValue;
            }

            // Sakoe-Chiba Band
            if (sakoeChibaBand > 0)
            {
                double step = (double)y.Length / (double)x.Length;
                for (int i = 1; i <= x.Length; ++i)
                {
                    for (int j = 1; j <= y.Length; ++j)
                    {
                        if (i * step > j + sakoeChibaBand ||
                            i * step < j - sakoeChibaBand)
                        {
                            _f[i, j] = int.MaxValue;
                        }
                    }
                }
            }

            _f[0, 0] = 0;
            _sum = ComputeFBackward(x.Length, y.Length);
        }

        /// <summary>
        /// Get the value of the calculated DTW.
        /// </summary>
        /// <returns>Value of the calculated DTW.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var serie1= new double[] { 0, 1, 2, 3, 4, 5 };
        /// var serie2 = new double[] { 5, 4, 3, 2, 1, 0 };
        /// int sakoeChibaBand = -1;
        /// var dtw = new DTW(serie1, serie2, sakoeChibaBand);
        /// var result = dtw.GetSum();
        /// 
        /// /*
        /// result is 18
        /// */
        /// </code>
        /// </example>
        public double GetSum()
        {
            return _sum;
        }

        /// <summary>
        /// Get the path of the calculated DTW.
        /// </summary>
        /// <returns>Path of the calculated DTW.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var serie1 = new double[] { 0, 1, 2, 3, 4 };
        /// var serie2 = new double[] { 0, 1, 2, 3, 4 };
        /// int sakoeChibaBand = -1;
        /// var dtw = new DTW(serie1, serie2, sakoeChibaBand);
        /// var result = dtw.GetPath();
        /// 
        /// /*
        /// result is [(0, 0), (1, 1), (2, 2), (3, 3), (4, 4)]
        /// */
        /// </code>
        /// </example>
        public Tuple<int, int>[] GetPath()
        {
            List<Tuple<int, int>> tupleBackward = ComputePathBackward(_x.Length, _y.Length);
            tupleBackward.RemoveAt(0);
            tupleBackward.Add(new Tuple<int, int>(_x.Length - 1, _y.Length - 1));
            return tupleBackward.ToArray();
        }

        private double ComputeFBackward(int i, int j)
        {
            if (!(_f[i, j] < 0))
            {
                return _f[i, j];
            }
            else
            {
                if (ComputeFBackward(i - 1, j) <= ComputeFBackward(i, j - 1) &&
                    ComputeFBackward(i - 1, j) <= ComputeFBackward(i - 1, j - 1) &&
                    ComputeFBackward(i - 1, j) < int.MaxValue)
                {
                    _f[i, j] = _distance[i - 1, j - 1] + ComputeFBackward(i - 1, j);
                }
                else if (ComputeFBackward(i, j - 1) <= ComputeFBackward(i - 1, j) &&
                         ComputeFBackward(i, j - 1) <= ComputeFBackward(i - 1, j - 1) &&
                         ComputeFBackward(i, j - 1) < int.MaxValue)
                {
                    _f[i, j] = _distance[i - 1, j - 1] + ComputeFBackward(i, j - 1);
                }
                else if (ComputeFBackward(i - 1, j - 1) <= ComputeFBackward(i - 1, j) &&
                         ComputeFBackward(i - 1, j - 1) <= ComputeFBackward(i, j - 1) &&
                         ComputeFBackward(i - 1, j - 1) < int.MaxValue)
                {
                    _f[i, j] = _distance[i - 1, j - 1] + ComputeFBackward(i - 1, j - 1);
                }
            }
            return _f[i, j];
        }

        private List<Tuple<int, int>> ComputePathBackward(int i, int j)
        {
            List<Tuple<int, int>> tupleBackward = new List<Tuple<int, int>>();

            if (i != 0 && j != 0)
            {
                if (_f[i - 1, j - 1] <= _f[i - 1, j] &&
                         _f[i - 1, j - 1] <= _f[i, j - 1])
                {
                    tupleBackward = ComputePathBackward(i - 1, j - 1);
                    tupleBackward.Add(new Tuple<int, int>(i - 2, j - 2));
                }
                else if (_f[i - 1, j] <= _f[i - 1, j - 1] &&
                    _f[i - 1, j] <= _f[i, j - 1])
                {
                    tupleBackward = ComputePathBackward(i - 1, j);
                    tupleBackward.Add(new Tuple<int, int>(i - 2, j - 1));
                }
                else if (_f[i, j - 1] <= _f[i - 1, j] &&
                         _f[i, j - 1] <= _f[i - 1, j - 1])
                {
                    tupleBackward = ComputePathBackward(i, j - 1);
                    tupleBackward.Add(new Tuple<int, int>(i - 1, j - 2));
                }
            }

            return tupleBackward;
        }
    }
}
