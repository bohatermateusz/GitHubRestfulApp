using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllegroGitHub.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace AllegroGitHub.Controllers.Tests
{
    [TestClass()]
    public class TestConnection
    {
        [TestMethod()]
        public void CheckConnectionTest()
        {
            string user = "John";
            string url = $"https://api.github.com/users/{user}/repos";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd(user);
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                   var cos =  response.Content.Headers.LastModified.HasValue;
                    var httpanswear = response.IsSuccessStatusCode;
                    if (httpanswear == true)
                    {
                        Assert.IsTrue(httpanswear);
                    }
                    else
                    {
                        Assert.IsFalse(httpanswear);
                    }
                }
            }
        }
    }
}