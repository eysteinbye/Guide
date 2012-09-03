using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Feature
{
    [Binding]
    public class ViewTVGuideSteps
    {
        [Given(@"I Have selected channel (.*)")]
        public void GivenIHaveSelectedAChannel(string chName)
        {
            ScenarioContext.Current.Set<string>(chName);
        }
        
        [When(@"I have selected a date (.*) days from today")]
        public void WhenIHaveSelectedTodaysDate(int days)
        {
            string chName = ScenarioContext.Current.Get<string>();
            BEO.Channel ch = new BEO.Channel(chName, DateTime.Now.AddDays(days));
            ScenarioContext.Current.Set<BEO.Channel>(ch);
        }

        [Then(@"the result should be a list of between (.*) and (.*) programs")]
        public void ThenTheResultShouldBeAListOfProgramsOnTheScreen(int fromSize, int toSize)
        {
            BEO.Channel ch = ScenarioContext.Current.Get<BEO.Channel>();
            Assert.IsTrue(ch.Programs.Count > fromSize && ch.Programs.Count < toSize);
        }
    }
}
