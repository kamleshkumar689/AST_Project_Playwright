using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Playwright;

namespace API_Test_Playwright.Pages
{
    public class UserClass : BaseClass
    {
        /**
        *   This will initialize playwright
        */
        public UserClass()
        {
            Task.Run(async () => await InitializePlaywright()).GetAwaiter().GetResult();
        }

        /**
        * Get Users List
        */
        public async Task getUsers()
        {
            string apiUrl = baseUrl + Endpoints.users;
            var response = await page.APIRequest.GetAsync(apiUrl);
            if (response.Status == 200)
            {

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
            }
            else
            {
                throw new Exception("API failed at Get Users");
            }
        }

        /**
       * Add User
       */
        public async Task addUser(string firstName, string lastName, int age)
        {
            string apiUrl = baseUrl + Endpoints.addUser;
            var data = new
            {
                firstName = firstName,
                lastName = lastName,
                age = age
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
                throw new Exception("API failed at Add User");
            }
        }


        public async Task updateUser(int id, string firstName, string lastName, int age)
        {
            string apiUrl = baseUrl + Endpoints.users + '/' + id;
            var data = new
            {
                firstName = firstName,
                lastName = lastName,
                age = age
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
                throw new Exception("API failed at update user");
            }
        }

        public async Task deleteUser(int id)
        {
            string apiUrl = baseUrl + Endpoints.users + '/' + id;
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
                throw new Exception("API failed at delete user");
            }
        }

        public async Task getUserPostsById(int userId)
        {
            string apiUrl = baseUrl + Endpoints.users + "/" + userId + "/posts";
            var response = await page.APIRequest.GetAsync(apiUrl);
            if (response.Status == 200)
            {

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
            }
            else
            {
                throw new Exception("API failed at Get User Posts");
            }
        }

        public async Task getUserToDosById(int userId)
        {
            string apiUrl = baseUrl + Endpoints.users + "/" + userId + "/todos";
            var response = await page.APIRequest.GetAsync(apiUrl);
            if (response.Status == 200)
            {

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);
            }
            else
            {
                throw new Exception("API failed at Get User ToDos");
            }
        }
    }
}