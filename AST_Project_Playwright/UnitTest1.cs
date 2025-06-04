using System.Net.Mime;
using API_Test_Playwright.Pages;
using Microsoft.Playwright;
using Newtonsoft.Json;

namespace API_Test_Playwright
{
    public class Tests
    {
        PostClass postClass = new PostClass();
        CommentClass commentClass = new CommentClass();

        [Test]
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

        [Test]
        public async Task APICommentWithGet()
        {
            await commentClass.getComments();
        }

        [Test]
        public async Task APICommentWithPost()
        {
            await commentClass.addComment("This makes all sense to me!", 3, 5);
        }

        [Test]
        public async Task APICommentWithPut()
        {
            await commentClass.updateComment(1, "This makes all sense to me!");
        }

        [Test]
        public async Task APICommentWithDelete()
        {
            await commentClass.deleteComment("1");
        }

    }
}