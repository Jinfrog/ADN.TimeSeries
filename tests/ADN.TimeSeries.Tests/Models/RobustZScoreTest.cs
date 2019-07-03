using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADN.TimeSeries.Tests
{
    public class RobustZScoreTest
    {
        [Fact]
        public void SetThreshold_Exception()
        {
            var zScore = new RobustZScore();

            Assert.Throws<ArgumentException>(() => zScore.SetThreshold(-1));
        }

        [Fact]
        public void SetInfluence_Exception_Bottom()
        {
            var zScore = new RobustZScore();

            Assert.Throws<ArgumentException>(() => zScore.SetInfluence(-1));
        }

        [Fact]
        public void SetInfluence_Exception_Top()
        {
            var zScore = new RobustZScore();

            Assert.Throws<ArgumentException>(() => zScore.SetInfluence(2));
        }

        [Fact]
        public void SetLag_Exception()
        {
            var zScore = new RobustZScore();

            Assert.Throws<ArgumentException>(() => zScore.SetLag(0));
        }

        [Theory]
        [ClassData(typeof(AddData))]
        public void Add(double[] value, double threshold, double influence, int lag, int expectedRisingFlank, int expectedFallingFlank)
        {
            var zScore = new RobustZScore();
            zScore.SetThreshold(threshold);
            zScore.SetInfluence(influence);
            zScore.SetLag(lag);

            int resultRisingFlank = 0;
            int resultFallingFlank = 0;

            for (int i = 0; i < value.Length; i++)
            {
                var detectedValue = zScore.Add(value[i]);

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
