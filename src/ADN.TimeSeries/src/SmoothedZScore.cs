using ADN.Helpers.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADN.TimeSeries
{
    public class SmoothedZScore
    {
        private List<double> _filteredY = new List<double>();
        private List<double> _avgFilter = new List<double>();
        private List<double> _stdFilter = new List<double>();

        private double _threshold = 0;
        private double _influence = 0;
        private int _lag = 10;


        public void SetThreshold(double threshold)
        {
            _threshold = threshold;
        }

        public void SetInfluence(double influence)
        {
            _influence = influence;
        }

        public void SetLag(int lag)
        {
            _lag = lag;
        }

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
                _avgFilter.Add(ListHelper.Mean(_filteredY, i - _lag, i));
                _stdFilter.Add(ListHelper.StandardDeviation(_filteredY, i - _lag, i));
            }
            else
            {
                _filteredY.Add(value);

                //Adjust the filters
                _avgFilter.Add(ListHelper.Mean(_filteredY, 0, i));
                _stdFilter.Add(ListHelper.StandardDeviation(_filteredY, 0, i));
            }

            return signal;
        }
    }
}
