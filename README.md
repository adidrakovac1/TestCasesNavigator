# Automated UI Tests for Navigator Website
This repository contains a set of automated UI tests for the www.navigator.ba website, implemented using Selenium WebDriver, C#, and NUnit. The tests implemented are smoke tests.

# Prerequisites
Before running the automated tests, make sure you have the following installed:
- Should use Edge browser because tests are made for that browser.
- .NET SDK: You need latest .NET SDK installed on your machine to run the tests. 
- You need Visual studio code installed.
- This project uses Selenium WebDriver to interact with the web browser for automated UI tests. The specific WebDriver you need EdgeDriver will be handled by the NuGet package manager.
- Browser Drivers: You will need to have the appropriate drivers EdgeDriver installed. These are typically handled by Selenium WebDriver, but they may need to be manually updated depending on your browser version.
- NuGet Packages you need to have: The project uses the following NuGet packages: Selenium.WebDriver, Selenium.WebDriver.MicrosoftDriver, NUnit, NUnit3TestAdapter, Microsoft.NET.Test.Sdk
- You will need visual studio code extensions like C# Dev kit and .NET install tool for extension authors.

# Stup instructions
1. Clone the repository:
    git clone https://github.com/adidrakovac1/TestCasesNavigator.git
    cd UITests
2. Open the project:
    - Open the project in Visual Studio Code
3. Install NuGet packages:
    - Open terminal and run the following command to install the required package:
    dotnet restore
4. Install browser drivers
    - Download the matching version from the link [Edge Webdriver](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/?form=MA13LH)

# Running the tests:
1. Build the project 
    - In Visual studio code open the terminal and run:
    dotnet build
2. Run the tests
    - Now in the terminal of the UITests run:
    dotnet test
3. The results of the testing should be shown following console log of that did it pass or fail.
