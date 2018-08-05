using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADN.TimeSeries.Tests
{
    public class SmoothedZScoreTest
    {
        [Theory]
        [ClassData(typeof(AddData))]
        public void Add(double[] value, double threshold, double influence, int lag, double[] expected)
        {
            var smoothedZScore = new SmoothedZScore();
            smoothedZScore.SetThreshold(threshold);
            smoothedZScore.SetInfluence(influence);
            smoothedZScore.SetLag(lag);

            var result = new List<double>();

            for (int i = 0; i < value.Length; i++)
            {
                result.Add(smoothedZScore.Add(value[i]));
            }

            Assert.Equal(expected, result.ToArray());
        }

        public class AddData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, -5, -5, -5, -5, -5, -5 },
                                            2, 5, 5,
                                            new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0 }};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
