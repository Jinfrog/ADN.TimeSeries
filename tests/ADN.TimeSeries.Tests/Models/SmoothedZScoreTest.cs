using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADN.TimeSeries.Tests
{
    public class SmoothedZScoreTest
    {
        [Fact]
        public void SetThreshold_Exception()
        {
            var smoothedZScore = new SmoothedZScore();

            Assert.Throws<ArgumentException>(() => smoothedZScore.SetThreshold(-1));
        }

        [Fact]
        public void SetInfluence_Exception_Bottom()
        {
            var smoothedZScore = new SmoothedZScore();

            Assert.Throws<ArgumentException>(() => smoothedZScore.SetInfluence(-1));
        }

        [Fact]
        public void SetInfluence_Exception_Top()
        {
            var smoothedZScore = new SmoothedZScore();

            Assert.Throws<ArgumentException>(() => smoothedZScore.SetInfluence(2));
        }

        [Fact]
        public void SetLag_Exception()
        {
            var smoothedZScore = new SmoothedZScore();

            Assert.Throws<ArgumentException>(() => smoothedZScore.SetLag(0));
        }

        [Theory]
        [ClassData(typeof(AddData))]
        public void Add(double[] value, double threshold, double influence, int lag, int expectedRisingFlank, int expectedFallingFlank)
        {
            var smoothedZScore = new SmoothedZScore();
            smoothedZScore.SetThreshold(threshold);
            smoothedZScore.SetInfluence(influence);
            smoothedZScore.SetLag(lag);

            int resultRisingFlank = 0;
            int resultFallingFlank = 0;
            double detectedValue = 0;

            for (int i = 0; i < value.Length; i++)
            {
                detectedValue = smoothedZScore.Add(value[i]);

                if (detectedValue == 1) resultRisingFlank++;
                else if (detectedValue == -1) resultFallingFlank++;
            }

            Assert.True(expectedRisingFlank == resultRisingFlank &&
                        expectedFallingFlank == resultFallingFlank);
        }

        public class AddData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, -5 },
                                            2, 0.5, 5, 1, 1};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
