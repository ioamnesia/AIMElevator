# AIMElevator

This repository contains code requested by AIM Consulting as part of their interview process.

## Scenario

You are a part of a new development team that is supplying an API (over http) that will be used by multiple dependent teams. It is your task to design the API and implement a minimal set of code that the other teams can use to test their integration. Unblocking those teams by creating the interface is more important than building a complete set of business logic.

You are tasked with designing an API for an elevator control system. Your API needs to account for the following scenarios:

* A person requests an elevator be sent to their current floor
* A person requests that they be brought to a floor
* An elevator car requests all floors that it’s current passengers are servicing (e.g. to light up the buttons that show which floors the car is going to)
* An elevator car requests the next floor it needs to service

## Running
Clone the repository and run *dotnet run* from the repository directory. Once started, you can navigate to https://localhost:8080/swagger or use a tool such as Postman to directly query the API.

## Functionality
| Functionality | Method | URI |
| ------------- | ------ | --- |
| Get All Elevators | GET | https://localhost:8080/elevators |
| Get Elevator | GET | https://localhost:8080/elevators/{id} |
| Get All Queued Stops | GET | https://localhost:8080/elevators/{id}/stops |
| Get Next Stop | GET |  https://localhost:8080/elevators/{id}/nextStop |
| Call Elevator | POST | https://localhost:8080/elevators/call?floor=2 |
| Add Stop to Elevator | POST | https://localhost:8080/elevators/{id}/dispatch?floor=2 |


