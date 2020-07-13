using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using APIServices;
using APIServices.ResponseModels;
using System.Linq;

namespace SDETApiTest.SpecFlowTests
{
    [Binding]
    public class CarsAPITestsSteps
    {
        private readonly IApiClientResources _apiClientResources;
        private IApiResponse<IEnumerable<Car>> _response;
        private string _type;

        public CarsAPITestsSteps(IApiClientResources apiClientResources)
        {
            _apiClientResources = apiClientResources;
        }

        [When(@"I request Get cars endpoint to fetch list of cars by specified (.*)")]
        public async Task WhenIRequestGetCarsEndpointToFetchListOfCarsBySpecifiedSaloon(string type)
        {
            _type = type;
            _response = await _apiClientResources.GetListCarsByTypeIdAsync(_type);
        }

        [Then(@"Returns status code (200|404)")]
        public void ThenReturnsStatusCode(HttpStatusCode httpStatusCodes)
        {
            Assert.IsTrue(_response.StatusCode.Equals(httpStatusCodes));
        }

        [Then(@"Response body is non-empty")]
        public void ThenResponseBodyIsNonEmpty()
        {
            Assert.IsNotNull(_response.Content);
        }

        [Then(@"Response body should contain the specified type")]
        public void ThenResponseBodyShouldContainTheSpecifiedType()
        {
            var cars = _response.Content;
            Assert.IsTrue(cars.All(car => car.Type.Equals(_type, StringComparison.InvariantCultureIgnoreCase)));
        }

    }
}

