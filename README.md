#.NET CORE WEB API

## Running Example of .NET CORE Web API in C#

This is a .NET CORE Web API where you can find full CRUD operation

## Table of Contents
- [.NET CORE Web API](#.NET CORE Web API)
    - [Table of Contents](#table-of-contents)
    - [Overview](#overview)
    - [Development](#development)
    - [Install Dependencies](#install-dependencies)
	-[Outcomes and How to call API](#outcomes-and-how-to-call-api)



## Overview
This is a .NET CORE Web API where you can find full CRUD operation. There is a model entity named as Person with 2 properties {Id, Name}. 

https://localhost:44373/api/

## Development
This project is a .NET CORE Web API example developed in C# to show the simple way of creating web api. This project includes the logger factory as well.

## Install Dependencies
The following packages are needed to be installed by NuGet Package Manager:

- Microsoft.AspNetCore.App

## Outcomes and How to call API

Call the api using Postman as this project does not have the view. 

POST
https://localhost:44373/api/AddPersion

GET
https://localhost:44373/api/GetPernsonByID/1

PUT
https://localhost:44373/api/UpdatePersonByID/3

DELETE
https://localhost:44373/api/DeletePersonByID/4


example:

API call:-

https://localhost:44373/api/AddPersion

Body Injection:-
{
	"Id": "1"
	, "Name" : "bb"
	
}
response:-

{
    "id": "1",
    "name": "bb"
}