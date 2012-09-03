Imports System
Imports TechTalk.SpecFlow

Namespace Features

    <Binding()> _
    Public Class ViewTVGuideSteps

        <TechTalk.SpecFlow.Given("I Have selected a channel")> _
        Public Sub GivenIHaveSelectedAChannel()
            ScenarioContext.Current.Pending()
        End Sub
        
        <TechTalk.SpecFlow.When("I have selected todays date")> _
        Public Sub WhenIHaveSelectedTodaysDate()
            ScenarioContext.Current.Pending()
        End Sub
        
        <TechTalk.SpecFlow.Then("the result should be a list of programs on the screen")> _
        Public Sub ThenTheResultShouldBeAListOfProgramsOnTheScreen()
            ScenarioContext.Current.Pending()
        End Sub

    End Class

End Namespace
