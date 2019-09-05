# Time series Library for .NET

ADN.TimeSeries is a cross-platform open-source library which provides time series utilities to .NET developers.

[![Build Status](https://travis-ci.org/andresdigiovanni/ADN.TimeSeries.svg?branch=master)](https://travis-ci.org/andresdigiovanni/ADN.TimeSeries)
[![NuGet](https://img.shields.io/nuget/v/ADN.TimeSeries.svg)](https://www.nuget.org/packages/ADN.TimeSeries/)
[![BCH compliance](https://bettercodehub.com/edge/badge/andresdigiovanni/ADN.TimeSeries?branch=master)](https://bettercodehub.com/)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=andresdigiovanni_ADN.TimeSeries&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=andresdigiovanni_ADN.TimeSeries)
[![Quality](https://sonarcloud.io/api/project_badges/measure?project=andresdigiovanni_ADN.TimeSeries&metric=alert_status)](https://sonarcloud.io/dashboard?id=andresdigiovanni_ADN.TimeSeries)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Basic usage

Dynamic time warping example:
<br/>
![DTW](resources/DTW.jpg)

```csharp
var serie1 = new double[] { 0, 1, 2, 3, 4 };
var serie2 = new double[] { 0, 1, 2, 3, 4 };
int sakoeChibaBand = -1;
var dtw = new DTW(serie1, serie2, sakoeChibaBand);

var result = dtw.GetPath();

/*
 result is [(0, 0), (1, 1), (2, 2), (3, 3), (4, 4)]
 */
```

## Installation

ADN.TimeSeries runs on Windows, Linux, and macOS.

Once you have an app, you can install the ADN.TimeSeries NuGet package from the NuGet package manager:

```
Install-Package ADN.TimeSeries
```

Or alternatively you can add the ADN.TimeSeries package from within Visual Studio's NuGet package manager.

## Examples

Please find examples and the documentation at the [wiki](https://github.com/andresdigiovanni/ADN.TimeSeries/wiki) of this repository.

## Contributing

We welcome contributions! Please review our [contribution guide](CONTRIBUTING.md).

## License

ADN.TimeSeries is licensed under the [MIT license](LICENSE).
