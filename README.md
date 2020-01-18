#  The CometX Project ![CometX COADM Logo - Variant 2 Fade (XS)](https://user-images.githubusercontent.com/11052295/71773316-ec693c00-2f20-11ea-96f8-f5a5cc830c39.png)

CometX allows you to use your own domain classes to represent the model that CometX relies on to perform any number of data accessing requirements such as querying, change tracking, and updating functions. 

CometX was built upon [Microsoft.Data.ApplicationBlocks](https://www.nuget.org/packages/Microsoft.ApplicationBlocks.Data/) with [Code First](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx) practices in mind, which leverages a programming pattern referred to as "[convention over configuration](https://markheath.net/post/convention-over-configuration)" (or coding by convention)

CometX is currently developed targeting net451, and plans to target netcore 2.1 are expected in the near future; ultimately, CometX is targeting compatibility among all operating systems (Windows, Linx, MacOS) by 06/01/2020 - see [Future Plans]() for more information.  

The following figure illustrates where CometX fits into your application. 
![CometX Architecture Backsplash](https://user-images.githubusercontent.com/11052295/71771649-51faff80-2f04-11ea-9245-2986587abf06.png)

# Quick Navigation 
```
1. Issues, Requests, and Help
2. Documentation 
3. Quick Installation 
4. Contributing 
5. Authors
6. Acknowledgements 
```

## 1. Issues, Requests, and Help 
Please utilize the [Issues](https://github.com/CarlosRangel17/CometX/issues) page for any issues, requests, or help needed with the CometX project.

## 2. Documentation 
Please find all relevant documentation and guides for CometX in the [Wiki](https://github.com/CarlosRangel17/CometX/wiki). 

## 3. Quick Installation

The CometX project currently offers one package for users of .Net Framework (v4.5.1 or greater). See [Future Plans](https://github.com/CarlosRangel17/CometX/wiki/Future-Plans) for .Net Core packages. 

To install the latest version, we strongly recommend that you use [NuGet](https://www.nuget.org/packages/CometX/) to add CometX to your project:

``` 
PM > Install-Package CometX -Version 1.6.2 
```

#### Main Libraries 
| Project Source | Nuget Package | Description | 
| --- | --- | --- |
| CometX.Attributes | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) | The Attributes library can be broken into two categories: <br/>1-Property, & 2-Relational. Both are used to add metadata<br/>to class properties which the CometX Project can utilize<br/>for a range of query & property operations. |
| CometX.Entities | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) | The Entities library contains predefined model's that are<br/>purposed for a variety of modelling requirements such as<br/>entity identifier mapping, folder/file mapping, and<br/>table/pagination modelling.  |
| CometX.Repository | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) | The Repository library houses the ORM-related functions<br/>and utilities that allow CometX to meet a variety of data<br/>access requirements. This library connects to the underlying<br/>ADO.NET data provider using Connection Strings.  |
| CometX.Service | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) | The Service library is a CometX factory that implements upon <br/>the CometX project libraries: `CometX.Repository`, `CometX.Attributes`, and `CometX.Entities`. |

End with an example of getting some data out of the system or using it for a little demo

## 4. Contributing

Please read [CONTRIBUTING.md](https://github.com/CarlosRangel17/CometX/blob/master/Good-CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## 5. Authors

* **Carlos Rangel** - *Initial work* - [CometX](https://github.com/CarlosRangel17/CometX)

See also the list of [contributors](https://github.com/CarlosRangel17/CometX/contributors) who participated in this project.

## 6. Acknowledgments

* Hat tip to [Keyur Patel](https://github.com/simkeyur) for becoming the official CometX Beta tester
* Inspirations include: [Nethereum](https://github.com/Nethereum/Nethereum), [iText](https://github.com/itext/itextsharp), [Flex Layout](https://github.com/angular/flex-layout)
