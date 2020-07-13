Feature: CarsAPITests
	In order to service cars
	As a service manger
	I want to fetch cars API endpoint

Scenario Outline: Get list of cars of valid specified type
	When I request Get cars endpoint to fetch list of cars by specified <type>
	Then Returns status code 200
	And Response body is non-empty
	And Response body should contain the specified type
Examples: 
	| type      |
	| Saloon    |
	| SUV       |
	| Hatchback |

Scenario Outline: Get list of cars of invalid specified type
	When I request Get cars endpoint to fetch list of cars by specified <invalidType>
	Then Returns status code 404
Examples: 
	| invalidType |
	| @Saloon     |
	| SUV123      |
	| 123         |
	|             |