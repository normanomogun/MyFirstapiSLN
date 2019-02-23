Feature: UserTests
	In order to get get correct data from an API 
	I want to make request and get response

@mytag
Scenario: Verify user from endpoint
	Given I have an /api/users/2
	When I make a request
	Then I should receive successful response
