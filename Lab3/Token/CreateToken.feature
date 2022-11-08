Feature: CreateToken

Scenario: Creating the create token request
	Given token request
	When send token request
	Then response is success
