# ADN.TimeSeries

# Content

- [DBA](#T:ADN.TimeSeries.DBA)

  - [Average(series, maxIterations)](#DBA.Average(series,maxIterations))

- [DTW](#T:ADN.TimeSeries.DTW)

  - [Constructor(x, y, sakoeChibaBand)](#DTW.#ctor(x,y,sakoeChibaBand))

  - [GetPath](#DTW.GetPath)

  - [GetSum](#DTW.GetSum)

- [Euclidean](#T:ADN.TimeSeries.Euclidean)

  - [Distance(serie1, serie2)](#Euclidean.Distance(serie1,serie2))

- [RobustZScore](#T:ADN.TimeSeries.RobustZScore)

- [SmoothedZScore](#T:ADN.TimeSeries.SmoothedZScore)

- [ZScore](#T:ADN.TimeSeries.ZScore)

  - [Add(value)](#ZScore.Add(value))

  - [SetInfluence(influence)](#ZScore.SetInfluence(influence))

  - [SetLag(lag)](#ZScore.SetLag(lag))

  - [SetThreshold(threshold)](#ZScore.SetThreshold(threshold))

<a name='T:ADN.TimeSeries.DBA'></a>


## DBA

A static class that implements DTW Barycenter Averaging.

<a name='DBA.Average(series,maxIterations)'></a>


### Average(series, maxIterations)

Generate average of supplied series.


#### Parameters

| Name | Description |
| ---- | ----------- |
| series | *System.Collections.Generic.IEnumerable{System.Double[]}*<br>Supplied series. |

#### Parameters

| maxIterations | *System.Int32*<br>Maximum number of iterations to calculate the average. |

*System.ArgumentNullException:* series is null


#### Example

```csharpvar series = new List<double[]>() {
new double[] { 0, 0, 0, 0, 0 },
new double[] { 2, 2, 2, 2, 2 }};
var result = DBA.Average(value);

/*
result is { 1, 1, 1, 1, 1 }
*/
```

<a name='T:ADN.TimeSeries.DTW'></a>


## DTW

Class to calculate the Dynamic Time Wrapping.

<a name='DTW.#ctor(x,y,sakoeChibaBand)'></a>


### Constructor(x, y, sakoeChibaBand)

Class constructor.


#### Parameters

| Name | Description |
| ---- | ----------- |
| x | *System.Double[]*<br>The first that contains data to calculate the DTW. |

#### Parameters

| y | *System.Double[]*<br>The second that contains data to calculate the DTW. |

#### Parameters

| sakoeChibaBand | *System.Int32*<br>Size of limits to warping path of first to be inside the second . |

*System.ArgumentNullException:* x is null

*System.ArgumentNullException:* y is null


#### Example

```csharp
var serie1= new double[] { 0, 1, 2, 3, 4, 5 };
var serie2 = new double[] { 5, 4, 3, 2, 1, 0 };
int sakoeChibaBand = -1;
var dtw = new DTW(serie1, serie2, sakoeChibaBand);
```

<a name='DTW.GetPath'></a>


### GetPath

Get the path of the calculated DTW.


#### Returns

Path of the calculated DTW.


#### Example

```csharp
var serie1= new double[] { 0, 1, 2, 3, 4 };
var serie2 = new double[] { 0, 1, 2, 3, 4 };
int sakoeChibaBand = -1;
var dtw = new DTW(serie1, serie2, sakoeChibaBand);
var result = dtw.GetPath();

/*
result is [(0, 0), (1, 1), (2, 2), (3, 3), (4, 4)]
*/
```

<a name='DTW.GetSum'></a>


### GetSum

Get the value of the calculated DTW.


#### Returns

Value of the calculated DTW.


#### Example

```csharp
var serie1= new double[] { 0, 1, 2, 3, 4, 5 };
var serie2 = new double[] { 5, 4, 3, 2, 1, 0 };
int sakoeChibaBand = -1;
var dtw = new DTW(serie1, serie2, sakoeChibaBand);
var result = dtw.GetSum();

/*
result is 18
*/
```

<a name='T:ADN.TimeSeries.Euclidean'></a>


## Euclidean

A static class that implements Euclidean distance algorithm.

<a name='Euclidean.Distance(serie1,serie2)'></a>


### Distance(serie1, serie2)

Get the value of the calculated Euclidean distance.


#### Parameters

| Name | Description |
| ---- | ----------- |
| serie1 | *System.Double[]*<br>The first that contains data to calculate the Euclidean distance. |

#### Parameters

| serie2 | *System.Double[]*<br>The second that contains data to calculate the Euclidean distance. |


#### Returns

Value of the calculated Euclidean distance.

*System.ArgumentNullException:* serie1 is null

*System.ArgumentNullException:* serie2 is null


#### Example

```csharp
var serie1 =  new double[] { 0, 0, 0, 0, 0, 0 };
var serie2 = new double[] { 1, 2, 3, 4, 5, 6 };
var result = Euclidean.Distance(serie1, serie2);

/*
result is 9.53
*/
```

<a name='T:ADN.TimeSeries.RobustZScore'></a>


## RobustZScore

Class that implements thresholding algorithm with robust average filter.

<a name='T:ADN.TimeSeries.SmoothedZScore'></a>


## SmoothedZScore

Class that implements thresholding algorithm with smoothed average filter.

<a name='T:ADN.TimeSeries.ZScore'></a>


## ZScore

Abstract class that implements thresholding algorithm.

<a name='ZScore.Add(value)'></a>


### Add(value)

Add a new point.


#### Parameters

| Name | Description |
| ---- | ----------- |
| value | *System.Double*<br>New point. |


#### Returns

Signal detected: 1 if positive signal, -1 if negative signal and 0 otherwise.


#### Example

```csharp
var smoothedZScore = new SmoothedZScore();
double[] points = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, -5 };

for (int i = 0; i < points.Length; i++)
{
double detectedValue = smoothedZScore.Add(value[i]);

if (detectedValue == 1) Console.WriteLine("Detected raise flank");
else if (detectedValue == -1) Console.WriteLine("Detected falling flank");
}
```

<a name='ZScore.SetInfluence(influence)'></a>


### SetInfluence(influence)

Set the influence.


#### Parameters

| Name | Description |
| ---- | ----------- |
| influence | *System.Double*<br>The influence (between 0 and 1) of new signals on the mean and standard deviation. |

*System.ArgumentException:* influence must to be between 0 and 1

<a name='ZScore.SetLag(lag)'></a>


### SetLag(lag)

Set the lag.


#### Parameters

| Name | Description |
| ---- | ----------- |
| lag | *System.Int32*<br>The lag of the moving window. |

*System.ArgumentException:* lag must be strictly positive

<a name='ZScore.SetThreshold(threshold)'></a>


### SetThreshold(threshold)

Set the threshold. The z-score at which the algorithm signals.


#### Parameters

| Name | Description |
| ---- | ----------- |
| threshold | *System.Double*<br>Value to signal if a datapoint is out of standard deviations away from the moving mean. |

*System.ArgumentException:* threshold must be positive

