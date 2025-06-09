using Microsoft.Playwright;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace API_Test_Playwright.Pages
{
    public class CommentClass : BaseClass
    {
        public CommentClass()
        {
            Task.Run(async () => await InitializePlaywright()).GetAwaiter().GetResult();
        }

        /**
        * Get Comments
        */
        public async Task getComments()
        {
            // await InitializePlaywright();
            string apiUrl = baseUrl + Endpoints.comments;
            var response = await page.APIRequest.GetAsync(apiUrl);
            if (response.Status == 200)
            {
                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
                Assert.Pass("Get Post's comments");
            }
            else
            {
                throw new Exception("API failed");
            }
        }

        /**
          * Add Comment
        */
        public async Task addComment(string body, int postId, int userId)
        {
            string apiUrl = baseUrl + Endpoints.addComment;
            var data = new
            {
                body = body,
                postId = postId,
                userId = userId
            };
            var jsonData = JsonConvert.SerializeObject(data);

            var headers = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };

            // Send the POST request
            var response = await page.APIRequest.PostAsync(apiUrl, new APIRequestContextOptions
            {
                Data = jsonData,
                Headers = headers
            });
            TestContext.WriteLine(response.Status);

            if (response.Status == 201)
            {

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
                Assert.Pass("Add Comment");
            }
            else
            {
                throw new Exception("API failed with post data");
            }
        }


        /**
          * Update Comment
        */
        public async Task updateComment(int id, string body)
        {
            string apiUrl = baseUrl + Endpoints.comments + '/' + id;
            TestContext.WriteLine($"Calling URL: {apiUrl}");
            var data = new
            {
                body = body,
            };
            var jsonData = JsonConvert.SerializeObject(data);

            var headers = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };

            // Send the POST request
            var response = await page.APIRequest.PutAsync(apiUrl, new APIRequestContextOptions
            {
                Data = jsonData,
                Headers = headers
            });
            TestContext.WriteLine($"Response: {response}");

            if (response.Status == 200)
            {
                TestContext.WriteLine("Data ");
                TestContext.WriteLine(response.Status);

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
                Assert.Pass("Update Comment");
            }
            else
            {
                throw new Exception("API failed with put data");
            }
        }

        /**
            * Delete Comment
        */
        public async Task deleteComment(string id)
        {
            string apiUrl = baseUrl + Endpoints.comments + '/' + id;
            var response = await page.APIRequest.DeleteAsync(apiUrl);
            TestContext.WriteLine(response.Status);

            if (response.Status == 200 || response.Status == 204)
            {
                TestContext.WriteLine("Data ");
                TestContext.WriteLine(response.Status);

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
                Assert.Pass("Delete Comment");
            }
            else
            {
                throw new Exception("API failed with delete task");
            }
        }
    }
}
