using System.Net.Mime;
using API_Test_Playwright.Pages;
using Microsoft.Playwright;
using Newtonsoft.Json;

namespace API_Test_Playwright
{
    public class Tests
    {
        PostClass postClass = new PostClass();

        [Test]
        public async Task APITestWithGet()
        {
            await postClass.getPosts();
        }

        [Test]
        public async Task APITestWithPost()
        {
            await postClass.addPost("11", "Testing with playwright", 100);
        }

        [Test]
        public async Task APITestWithPut()
        {
            await postClass.updatePost("11", "Testing new POM playwright", 95);
        }

        [Test]
        public async Task APITestWithDelete()
        {
            await postClass.deletePost("10");
        }

    }
}