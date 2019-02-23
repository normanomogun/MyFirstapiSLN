Feature: UserTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Verify user from endpoint
	Given I have an /api/users/2
	When I make a request
	Then I should receive successful response
