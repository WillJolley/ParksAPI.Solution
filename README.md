# _Parks API._

#### By _Will Jolley_

#### _An API for national and state parks_

## Technologies Used

* C#
* .NET 6.0
* Entity Framework Core
* JSON


## Description

ParksAPI is an ASP.NET Core web API that allows users to populate a database with national and state parks, as well as edit and delete their entries. Users are able to view all the parks in the database and filter their results through pagination as well as by the state the parks are located in.     

## Setup Instructions

- Note: An installation of the .NET SDK is required in order to run this application locally. [See Here](https://dotnet.microsoft.com/en-us/) for installation.

- Optionally, download and install Postman [here](https://www.postman.com/downloads/).

1. Clone this repo.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's directory called "ParksAPI/". 
3. Create a file named `appsettings.json`: `$ touch appsettings.json`
4. Within `appsettings.json` add the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.

    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=parks_api;uid=[Your UserID];pwd=[Your Password];"
      }
    }
    ```
5. Set up the database: `$ dotnet ef database update`
6. Navigate to the project directory: `$ cd ParksAPI`
7. Run `$ dotnet watch run` in the command line to start the project in development mode with a watcher.
8. Open the browser at: _https://localhost:7030/swagger/index.html_. If you cannot access localhost:7030 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## Endpoints

Base URL: 
  ```
  https://localhost:7030
  ```

HTTP Request Structure
  ```
  GET /api/Parks
  GET(by id) /api/Parks/{id}
  GET(by state) /api/Parks?state=[name of state]
  POST /api/Parks/{id}
  PUT /api/Parks/{id}
  DELETE /api/Parks/{id}
  ```

Example GET Request
  ```
  https://localhost:7030/api/Parks/2
  ```

Sample Response Body
  ```
  {
    "parkId": 2,
    "name": "Beacon Rock State Park",
    "state": "Washington",
    "features": "Beacon Rock, Hardy Ridge Trail"
  }
  ```

Search By State Example Request
  ```
  https://localhost:7030/api/Parks?state=washington
  ```

Sample Response Body
  ```
  {
    "parkId": 1,
    "name": "Olympic National Park",
    "state": "Washington",
    "features": "Lake Crescent, Hoh River"
  },
  {
    "parkId": 2,
    "name": "Beacon Rock State Park",
    "state": "Washington",
    "features": "Beacon Rock, Hardy Ridge Trail"
  }
  ```

  Example POST Request
  ```
  https://localhost:7030/api/Parks

  {
    "name": "Yellowstone National Park",
    "state": "Colorado",
    "features": "Geysers" 
  }
  ```
  * Requests must be made in JSON 
  * "name" and "state" parameters are required; "features" is an optional parameter
  * parkId is auto-implemented

  Example PUT Request
  ```
  https://localhost:7030/api/Parks/{id}

  {
    "parkId": 11,
    "name": "Fort Stevens State Park",
    "state": "Oregon"
  }
  ```
  * parkId must be declared in the request body for PUT requests

  Example DELETE Request
  ```
  https://localhost:7030/api/Parks/{id}

  {
    "parkId": 72,
    "name": "Acadia National Park",
    "state": "Maine"
  }
  ```
  * parkId must be declared in the request body for DELETE requests too


## Pagination

Users are able to define the number of entries listed per page (page size) and which page they would like to view (page number).
Page number and page size can be specified in the url as follows:

Example
  ```
  https://localhost:7030/api/Parks/paging-filter?pageNumber=1&pageSize=3
  ```

Sample Response Body
  ```
  {
      "parkId": 1,
      "name": "Olympic National Park",
      "state": "Washington",
      "features": "Lake Crescent, Hoh River"
  },
  {
      "parkId": 2,
      "name": "Beacon Rock State Park",
      "state": "Washington",
      "features": "Beacon Rock, Hardy Ridge Trail"
  },
  {
      "parkId": 3,
      "name": "Zion National Park",
      "state": "Utah",
      "features": "Angels Landing, Weeping Rock"
  }
  ```

## Known Bugs

N/A

## License

e-mail me at yeswilljolley@gmail.com with any issues, questions, ideas, concerns.

MIT

Copyright (c) 2023 Will Jolley