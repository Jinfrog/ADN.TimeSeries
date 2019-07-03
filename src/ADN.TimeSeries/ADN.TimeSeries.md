<a name='assembly'></a>
# ADN.TimeSeries

## Contents

- [DBA](#T-ADN-TimeSeries-DBA 'ADN.TimeSeries.DBA')
  - [Average(series,maxIterations)](#M-ADN-TimeSeries-DBA-Average-System-Collections-Generic-IEnumerable{System-Double[]},System-Int32- 'ADN.TimeSeries.DBA.Average(System.Collections.Generic.IEnumerable{System.Double[]},System.Int32)')
- [DTW](#T-ADN-TimeSeries-DTW 'ADN.TimeSeries.DTW')
  - [#ctor(x,y,sakoeChibaBand)](#M-ADN-TimeSeries-DTW-#ctor-System-Double[],System-Double[],System-Int32- 'ADN.TimeSeries.DTW.#ctor(System.Double[],System.Double[],System.Int32)')
  - [GetPath()](#M-ADN-TimeSeries-DTW-GetPath 'ADN.TimeSeries.DTW.GetPath')
  - [GetSum()](#M-ADN-TimeSeries-DTW-GetSum 'ADN.TimeSeries.DTW.GetSum')
- [Euclidean](#T-ADN-TimeSeries-Euclidean 'ADN.TimeSeries.Euclidean')
  - [Distance(serie1,serie2)](#M-ADN-TimeSeries-Euclidean-Distance-System-Double[],System-Double[]- 'ADN.TimeSeries.Euclidean.Distance(System.Double[],System.Double[])')
- [RobustZScore](#T-ADN-TimeSeries-RobustZScore 'ADN.TimeSeries.RobustZScore')
  - [Add(value)](#M-ADN-TimeSeries-RobustZScore-Add-System-Double- 'ADN.TimeSeries.RobustZScore.Add(System.Double)')
  - [SetInfluence(influence)](#M-ADN-TimeSeries-RobustZScore-SetInfluence-System-Double- 'ADN.TimeSeries.RobustZScore.SetInfluence(System.Double)')
  - [SetLag(lag)](#M-ADN-TimeSeries-RobustZScore-SetLag-System-Int32- 'ADN.TimeSeries.RobustZScore.SetLag(System.Int32)')
  - [SetThreshold(threshold)](#M-ADN-TimeSeries-RobustZScore-SetThreshold-System-Double- 'ADN.TimeSeries.RobustZScore.SetThreshold(System.Double)')
- [SmoothedZScore](#T-ADN-TimeSeries-SmoothedZScore 'ADN.TimeSeries.SmoothedZScore')
  - [Add(value)](#M-ADN-TimeSeries-SmoothedZScore-Add-System-Double- 'ADN.TimeSeries.SmoothedZScore.Add(System.Double)')
  - [SetInfluence(influence)](#M-ADN-TimeSeries-SmoothedZScore-SetInfluence-System-Double- 'ADN.TimeSeries.SmoothedZScore.SetInfluence(System.Double)')
  - [SetLag(lag)](#M-ADN-TimeSeries-SmoothedZScore-SetLag-System-Int32- 'ADN.TimeSeries.SmoothedZScore.SetLag(System.Int32)')
  - [SetThreshold(threshold)](#M-ADN-TimeSeries-SmoothedZScore-SetThreshold-System-Double- 'ADN.TimeSeries.SmoothedZScore.SetThreshold(System.Double)')

<a name='T-ADN-TimeSeries-DBA'></a>
## DBA `type`

##### Namespace

ADN.TimeSeries

##### Summary

A static class that implements DTW Barycenter Averaging.

<a name='M-ADN-TimeSeries-DBA-Average-System-Collections-Generic-IEnumerable{System-Double[]},System-Int32-'></a>
### Average(series,maxIterations) `method`

##### Summary

Generate average of supplied series.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| series | [System.Collections.Generic.IEnumerable{System.Double[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Double[]}') | Supplied series. |
| maxIterations | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Maximum number of iterations to calculate the average. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | series is null |

##### Example

```csharp
<![CDATA[var series = new List<double[]>() {]]> 
```

<a name='T-ADN-TimeSeries-DTW'></a>
## DTW `type`

##### Namespace

ADN.TimeSeries

##### Summary

Class to calculate the Dynamic Time Wrapping.

<a name='M-ADN-TimeSeries-DTW-#ctor-System-Double[],System-Double[],System-Int32-'></a>
### #ctor(x,y,sakoeChibaBand) `constructor`

##### Summary

Class constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Double[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double[] 'System.Double[]') | The first [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array')that contains data to calculate the DTW. |
| y | [System.Double[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double[] 'System.Double[]') | The second [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array')that contains data to calculate the DTW. |
| sakoeChibaBand | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Size of limits to warping path of first [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array')to be inside the second [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | x is null |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | y is null |

##### Example

```csharp
var serie1= new double[] { 0, 1, 2, 3, 4, 5 };
var serie2 = new double[] { 5, 4, 3, 2, 1, 0 };
int sakoeChibaBand = -1;
var dtw = new DTW(serie1, serie2, sakoeChibaBand); 
```

<a name='M-ADN-TimeSeries-DTW-GetPath'></a>
### GetPath() `method`

##### Summary

Get the path of the calculated DTW.

##### Returns

Path of the calculated DTW.

##### Parameters

This method has no parameters.

##### Example

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

<a name='M-ADN-TimeSeries-DTW-GetSum'></a>
### GetSum() `method`

##### Summary

Get the value of the calculated DTW.

##### Returns

Value of the calculated DTW.

##### Parameters

This method has no parameters.

##### Example

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

<a name='T-ADN-TimeSeries-Euclidean'></a>
## Euclidean `type`

##### Namespace

ADN.TimeSeries

##### Summary

A static class that implements Euclidean distance algorithm.

<a name='M-ADN-TimeSeries-Euclidean-Distance-System-Double[],System-Double[]-'></a>
### Distance(serie1,serie2) `method`

##### Summary

Get the value of the calculated Euclidean distance.

##### Returns

Value of the calculated Euclidean distance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| serie1 | [System.Double[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double[] 'System.Double[]') | The first [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array')that contains data to calculate the Euclidean distance. |
| serie2 | [System.Double[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double[] 'System.Double[]') | The second [Array](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Array 'System.Array')that contains data to calculate the Euclidean distance. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | serie1 is null |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | serie2 is null |

##### Example

```csharp
var serie1 =  new double[] { 0, 0, 0, 0, 0, 0 };
var serie2 = new double[] { 1, 2, 3, 4, 5, 6 };
var result = Euclidean.Distance(serie1, serie2);
/*
result is 9.53
*/ 
```

<a name='T-ADN-TimeSeries-RobustZScore'></a>
## RobustZScore `type`

##### Namespace

ADN.TimeSeries

##### Summary

Class that implements thresholding algorithm.

<a name='M-ADN-TimeSeries-RobustZScore-Add-System-Double-'></a>
### Add(value) `method`

##### Summary

Add a new point.

##### Returns

Signal detected: 1 if positive signal, -1 if negative signal and 0 otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | New point. |

##### Example

```csharp
var smoothedZScore = new SmoothedZScore();
double[] points = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, -5 }; 
```

<a name='M-ADN-TimeSeries-RobustZScore-SetInfluence-System-Double-'></a>
### SetInfluence(influence) `method`

##### Summary

Set the influence.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| influence | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The influence (between 0 and 1) of new signals on the mean and standard deviation. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | influence must to be between 0 and 1 |

<a name='M-ADN-TimeSeries-RobustZScore-SetLag-System-Int32-'></a>
### SetLag(lag) `method`

##### Summary

Set the lag.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lag | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The lag of the moving window. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | lag must be strictly positive |

<a name='M-ADN-TimeSeries-RobustZScore-SetThreshold-System-Double-'></a>
### SetThreshold(threshold) `method`

##### Summary

Set the threshold. The z-score at which the algorithm signals.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| threshold | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Value to signal if a datapoint is out of standard deviations away from the moving mean. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | threshold must be positive |

<a name='T-ADN-TimeSeries-SmoothedZScore'></a>
## SmoothedZScore `type`

##### Namespace

ADN.TimeSeries

##### Summary

Class that implements thresholding algorithm.

<a name='M-ADN-TimeSeries-SmoothedZScore-Add-System-Double-'></a>
### Add(value) `method`

##### Summary

Add a new point.

##### Returns

Signal detected: 1 if positive signal, -1 if negative signal and 0 otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | New point. |

##### Example

```csharp
var smoothedZScore = new SmoothedZScore();
double[] points = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, -5 }; 
```

<a name='M-ADN-TimeSeries-SmoothedZScore-SetInfluence-System-Double-'></a>
### SetInfluence(influence) `method`

##### Summary

Set the influence.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| influence | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The influence (between 0 and 1) of new signals on the mean and standard deviation. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | influence must to be between 0 and 1 |

<a name='M-ADN-TimeSeries-SmoothedZScore-SetLag-System-Int32-'></a>
### SetLag(lag) `method`

##### Summary

Set the lag.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lag | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The lag of the moving window. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | lag must be strictly positive |

<a name='M-ADN-TimeSeries-SmoothedZScore-SetThreshold-System-Double-'></a>
### SetThreshold(threshold) `method`

##### Summary

Set the threshold. The z-score at which the algorithm signals.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| threshold | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Value to signal if a datapoint is out of standard deviations away from the moving mean. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | threshold must be positive |
