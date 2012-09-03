Feature: View TV Guide
	In order to know whats on TV
	As a lazy person
	I want to see the guide on my iPad and not change channels

@mytag
Scenario: ViewTodaysProgram
	Given I Have selected a channel
	When I have selected todays date
	Then the result should be a list of programs on the screen
