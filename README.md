# Automated UI Tests for Navigator Website

This repository contains a set of automated UI tests for the **www.navigator.ba** website, implemented using **Selenium WebDriver**, **C#**, and **NUnit**. The tests implemented are **smoke tests**.

## Prerequisites

Before running the automated tests, make sure you have the following installed:

- **Edge browser**: The tests are designed for Microsoft Edge.
- **.NET SDK**: You need the latest **.NET SDK** installed on your machine to run the tests. [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet).
- **Visual Studio Code**: This project is set up to be worked on with **Visual Studio Code**.
- **Selenium WebDriver**: This project uses **Selenium WebDriver** to interact with the browser. The **EdgeDriver** required for Edge is managed via NuGet.
- **Browser Drivers**: Ensure the appropriate version of **EdgeDriver** is installed. You can download it from the [Edge WebDriver](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/?form=MA13LH) site. The WebDriver may be automatically managed by Selenium WebDriver, but you may need to manually update it depending on the browser version.
- **NuGet Packages**: The project uses the following NuGet packages:
    - **Selenium.WebDriver**
    - **Selenium.WebDriver.MicrosoftDriver**
    - **NUnit**
    - **NUnit3TestAdapter**
    - **Microsoft.NET.Test.Sdk**
- **Visual Studio Code Extensions**:
    - **C# Dev Kit** for syntax highlighting and intellisense.
    - **.NET Install Tool for Extension Authors** to support building and running tests.

## Setup Instructions

1. **Clone the repository**:

    Open a terminal and run the following command to clone the repository:

    ```bash
    git clone https://github.com/adidrakovac1/TestCasesNavigator.git
    cd UITests
    ```

2. **Open the project**:

    Open the project in **Visual Studio Code**.

3. **Install NuGet packages**:

    Open the terminal in Visual Studio Code and run the following command to restore the required NuGet packages:

    ```bash
    dotnet restore
    ```

4. **Install browser drivers**:

    Download the matching version of **Edge WebDriver** from the [Edge WebDriver download page](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/?form=MA13LH).

## Running the Tests

1. **Build the project**:

    In the terminal, build the project by running:

    ```bash
    dotnet build
    ```

2. **Run the tests**:

    After building the project, run the automated tests by executing the following command in the terminal:

    ```bash
    dotnet test
    ```

3. **Check the results**:

    After running the tests, the results will be shown in the console, indicating whether the tests passed or failed.

