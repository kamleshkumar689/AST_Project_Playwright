using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Playwright;
using NUnit.Framework;

namespace API_Test_Playwright.Pages
{
    public class ToDoClass : BaseClass
    {
        /**
        *   This will initialize playwright
        */
        public ToDoClass()
        {
            Task.Run(async () => await InitializePlaywright()).GetAwaiter().GetResult();
        }
        

           /**
        * Get Users List
        */
        public async Task getToDos()
        {
            string apiUrl = baseUrl + Endpoints.toDos;
            var response = await page.APIRequest.GetAsync(apiUrl);
            if (response.Status == 200)
            {

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);

                Assert.Pass("Get Todos");
            }
            else
            {
                throw new Exception("API failed at Get ToDos");
            }
        }

        /**
       * Add User
       */
        public async Task addToDo(string todo, bool completedStatus, int userId)
        {
            string apiUrl = baseUrl + Endpoints.addToDo;
            var data = new
            {
                todo = todo,
                completed = completedStatus,
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
                TestContext.WriteLine("Data ");
                TestContext.WriteLine(response.Status);

                var responseData = await response.BodyAsync();
                var responseText = System.Text.Encoding.UTF8.GetString(responseData);
                TestContext.WriteLine("Response Data: ");
                TestContext.WriteLine(responseText);

                Assert.Pass("Add todo");
            }
            else
            {
                throw new Exception("API failed at Add toDo");
            }
        }


        public async Task updateToDo(int id, bool completedStatus)
        {
            string apiUrl = baseUrl + Endpoints.toDos + "/" + id;
            var data = new
            {
                completed = completedStatus,
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
                Assert.Pass("Update Todo");
            }
            else
            {
                throw new Exception("API failed at update todo");
            }
        }

        public async Task deleteToDo(int id)
        {
            string apiUrl = baseUrl + Endpoints.toDos + "/" + id;
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
                Assert.Pass("Delete Todo");
            }
            else
            {
                throw new Exception("API failed at delete toDo");
            }
        }

    }
}