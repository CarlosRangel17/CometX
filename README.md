# About CometX  

CometX allows you to use your own domain classes to represent the model that CometX relies on to perform any number of data accessing requirements such as querying, change tracking, and updating functions. 

CometX was built upon [Microsoft.Data.ApplicationBlocks](https://www.nuget.org/packages/Microsoft.ApplicationBlocks.Data/) with [Code First](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx) practices in mind, which leverages a programming pattern referred to as "[convention over configuration](https://markheath.net/post/convention-over-configuration)" (or coding by convention)

CometX is currently developed targeting net451, and plans to target netcore 2.1 are expected in the near future; ultimately, CometX is targeting compatibility among all operating systems (Windows, Linx, MacOS) by 06/01/2020 - see [Future Plans]() for more information.  

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

What things you need to install the software and how to install them

```
1. Install .Net 
2. Create your app
3. 
```

#### 1. Install .Net
CometX works with .Net Framework (from 4.5.1 upwards). You’ll need to have the .Net SDK installed. For new starters we recommend .Net core. Mac or Linux users will also need .Net Core.

Not sure which .Net SDK to download? - choose .Net Framework 4.8.

[Download .Net SDK](https://dotnet.microsoft.com/download)

### Quick Installation

The CometX project currently offers one package for users of .Net Framework (v4.5.1 or greater). See [Future Plans](https://github.com/CarlosRangel17/CometX/wiki/Future-Plans) for .Net Core packages. 

To install the latest version, we strongly recommend that you use [NuGet](https://www.nuget.org/packages/CometX/) to add CometX to your project:

``` 
PM > Install-Package CometX -Version 1.6.2 
```

### What's included? 
#### Main Libraries 
| Project Source | Nuget Package | Description | 
| --- | --- | --- |
| CometX.Attributes | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) |  |
| CometX.Entities | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) | Words, words, words |
| CometX.Repository | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) | Words, words, words |
| CometX.Service | ![image](https://user-images.githubusercontent.com/11052295/71768303-9ec9e080-2eda-11ea-81f2-4b7eecb43294.png) | Words, words, words |

End with an example of getting some data out of the system or using it for a little demo

## Running the tests

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
