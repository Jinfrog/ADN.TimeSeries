using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADN.TimeSeries.Tests
{
    public class EuclideanTest
    {
        [Theory]
        [ClassData(typeof(EuclideanDistanceData))]
        public void EuclideanDistance(double[] x, double[] y, double expected)
        {
            var result = Euclidean.Distance(x, y);
            result = Math.Truncate(result * 100) / 100;

            Assert.Equal(expected, result);
        }

        public class EuclideanDistanceData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new double[] { 0, 0, 0, 0, 0, 0 },
                                            new double[] { 0, 0, 0, 0, 0, 0 }, 0 };
                yield return new object[] { new double[] { 0, 0, 0, 0, 0, 0 },
                                            new double[] { 1, 1, 1, 1, 1, 1 }, 2.44 };
                yield return new object[] { new double[] { 0, 0, 0, 0, 0, 0 },
                                            new double[] { 1, 2, 3, 4, 5, 6 }, 9.53 };
                yield return new object[] { new double[] { 5, 4, 3, 2, 1, 0 },
                                            new double[] { 0, 1, 2, 3, 4, 5 }, 8.36 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
