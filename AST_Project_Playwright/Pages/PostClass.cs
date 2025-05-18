using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Playwright;

namespace API_Test_Playwright.Pages
{
    public class PostClass : BaseClass
    {
        /**
        *   This will initialize playwright
        */
        public PostClass()
        {
            Task.Run(async () => await InitializePlaywright()).GetAwaiter().GetResult();
        }

        /**
        * Get Posts
        */
        public async Task getPosts()
        {
            // await InitializePlaywright();
            string apiUrl = baseUrl + Endpoints.posts;
            var response = await page.APIRequest.GetAsync(apiUrl);
            if (response.Status == 200)
            {
                TestContext.WriteLine("API is responding back");

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
            }
            else
            {
                throw new Exception("API failed");
            }
        }

        /**
        * Add Post
        */
        public async Task addPost(int userId, string title, string body)
        {
            string apiUrl = baseUrl + Endpoints.addPost;
            var data = new
            {
                userId = userId,
                title = title,
                body = body
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
                TestContext.WriteLine("Data ");
                TestContext.WriteLine(response.Status);

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
            }
            else
            {
                throw new Exception("API failed with post data");
            }
        }

        public async Task updatePost(int id, string title, string body)
        {
            string apiUrl = baseUrl + Endpoints.posts + '/' + id;
            var data = new
            {
                id = id,
                title = title,
                body = body
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
            TestContext.WriteLine(response.Status);

            if (response.Status == 200)
            {
                TestContext.WriteLine("Data ");
                TestContext.WriteLine(response.Status);

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
            }
            else
            {
                throw new Exception("API failed with put data");
            }
        }

        public async Task deletePost(int id)
        {
            string apiUrl = baseUrl + Endpoints.posts + '/' + id;
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
            }
            else
            {
                throw new Exception("API failed with delete task");
            }
        }
    }
}