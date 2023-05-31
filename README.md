# Man power C# samples

## Overview

The files in this directory each implement a demo class for a specific Google
Wallet pass type. Each class implements methods for performing tasks such as
creating a pass class, updating issuer permissions, and more.

## Prerequisites

*   .NET 6.0
*   Download the CSV file from files folder add more data if required.

## How to use the code samples

1.  Open the [`ManpowerApp.csproj`](./wallet-rest-samples.csproj) file
    in your .NET editor of choice.
2.  Copy the path to the employee and task csv file in config.json

    ```
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="7.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="7.0.0" />
    <PackageReference Include="Microsoft.Extensions.Hosting" Version="7.0.1" />
    <PackageReference Include="Microsoft.Extensions.Hosting.Abstractions" Version="7.0.0" />
    ```

3.  Build the project to install the dependencies.
4.  In your C# code, import a demo class and call its method(s). An example
    can be found below

    ```csharp
    // Create a demo class instance
    Program p = new Program();

    // create a configration method to read config.json file for .csv file path.
    var builder = new ConfigurationBuilder();

    // Create a function to read employee .csv file data.
    p.ReadCSVDataForEmployee(employeeFilePath);

    // Create a function to read task .csv file data.
    p.ReadCSVDataForTask(taskFilePath);

    // calling Generate task assignments and Save assignments to CSV file method.
    p.Getdetails();

    // create a manpoer class instance.
    var manpowerPlanner = new ManpowerPlanner(employees, tasks);
    
    // Create a function to Generate task assignments.
    manpowerPlanner.GenerateAssignments();

    // Create a function to Save assignments to CSV file.
    assignmentRepository.SaveAssignments(assignments,rootFilePath);
    ```