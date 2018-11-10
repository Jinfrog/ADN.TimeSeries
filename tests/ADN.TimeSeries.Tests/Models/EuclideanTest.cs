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

        [Fact]
        public void EuclideanDistance_Exception_x_Empty()
        {
            double[] x = new double[] { };
            double[] y = new double[] { 0, 1, 2, 3, 4, 5 };
            Assert.Throws<ArgumentNullException>(() => Euclidean.Distance(x, y));
        }

        [Fact]
        public void EuclideanDistance_Exception_x_Null()
        {
            double[] x = null;
            double[] y = new double[] { 0, 1, 2, 3, 4, 5 };
            Assert.Throws<ArgumentNullException>(() => Euclidean.Distance(x, y));
        }

        [Fact]
        public void EuclideanDistance_Exception_y_Empty()
        {
            double[] x = new double[] { 0, 1, 2, 3, 4, 5 };
            double[] y = new double[] { };
            Assert.Throws<ArgumentNullException>(() => Euclidean.Distance(x, y));
        }

        [Fact]
        public void EuclideanDistance_Exception_y_Null()
        {
            double[] x = new double[] { 0, 1, 2, 3, 4, 5 };
            double[] y = null;
            Assert.Throws<ArgumentNullException>(() => Euclidean.Distance(x, y));
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
