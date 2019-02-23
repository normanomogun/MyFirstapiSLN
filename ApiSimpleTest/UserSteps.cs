using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFramework;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ApiSimpleTest
{
    [Binding]
    public class UserSteps
    {
        ApiHelper apiHelper = new ApiHelper();
        User user = new User();
        [Given(@"I have an (.*)")]
        public void GivenIHaveAnEndpoint(string endPoint)
        {
            apiHelper.SetEndpoint(endPoint);
        }

        [When(@"I make a request")]
        public void WhenIMakeARequest()
        {
           var request =  apiHelper.MakeRequest();
           var response = apiHelper.GetResponse(request);
            user = JsonConvert.DeserializeObject<User>(response.Content);
        }

        [Then(@"I should receive successful response")]
        public void ThenIShouldReceiveSuccessfulResponse()
        {
            string expectedFirstName = "Janet";
            Assert.AreEqual(expectedFirstName,user.data.First_Name, "first name is not correct please try again");
            Console.WriteLine($"The name of user is : {expectedFirstName}");
        }

    }
}
