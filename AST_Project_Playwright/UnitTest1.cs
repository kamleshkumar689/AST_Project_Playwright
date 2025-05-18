using System.Net.Mime;
using API_Test_Playwright.Pages;
using Microsoft.Playwright;
using Newtonsoft.Json;

namespace API_Test_Playwright
{
    public class Tests
    {
        PostClass postClass = new PostClass();

        // [Test]
        public async Task GetAllPostsTest()
        {
            await postClass.getPosts();
        }

        [Test]
        public async Task AddPostTest()
        {
            /**
            * It required 3 params
            * userId, title and body
            */
            await postClass.addPost(
                5,
                "Testing with playwright",
                "This is my first case of add post"
            );
        }

        [Test]
        public async Task UpdatePostTest()
        {
            /**
            * It required 3 params
            * postId, title and body
            */
            await postClass.updatePost(
                30,
                "Testing new POM playwright",
                "Testing new POM playwright"
            );
        }

        [Test]
        public async Task DeletePostTest()
        {
            await postClass.deletePost(30);
        }

    }
}