Feature: View TV Guide
	In order to know whats on TV
	As a lazy person
	I want to see the guide on my iPad and not change channels

@mytag
Scenario: ViewTodaysProgram
	Given I Have selected channel motor.viasat.no
	When I have selected a date 3 days from today
	Then the result should be a list of between 1 and 25 programs 

Scenario: ViewNonExistingFutureProgram
	Given I Have selected channel motor.viasat.no
	When I have selected a date 33 days from today
	Then the result should be a list of between -1 and 1 programs 

Scenario: ViewNonExistingChannel
	Given I Have selected channel doesNotExist
	When I have selected a date 2 days from today
	Then the result should be a list of between -1 and 1 programs 
