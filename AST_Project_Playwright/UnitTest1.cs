using System.Net.Mime;
using NUnit.Framework;
using API_Test_Playwright.Pages;
using Microsoft.Playwright;
using Newtonsoft.Json;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace API_Test_Playwright
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("API Tests")]
    public class Tests
    {
        PostClass postClass = new PostClass();
        CommentClass commentClass = new CommentClass();
        UserClass userClass = new UserClass();
        ToDoClass toDoClass = new ToDoClass();


        /********************* Posts and Comments Test Cases **********************/
        [Test]
        [AllureDescription("Get All Posts.")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task GetAllPostsTest()
        {
            await postClass.getPosts();
        }

        [Test]
        [AllureDescription("Add new post.")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
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
        [AllureDescription("Update Post")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
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
        [AllureDescription("Delete Post")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task DeletePostTest()
        {
            await postClass.deletePost(30);
        }

        [Test]
        [AllureDescription("Get post's comments.")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task GetCommentsTest()
        {
            await commentClass.getComments();
        }

        [Test]
        [AllureDescription("Add new comments.")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task AddCommentTest()
        {
            await commentClass.addComment("This makes all sense to me!", 3, 5);
        }

        [Test]
        [AllureDescription("update comments")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task UpdateCommentTest()
        {
            await commentClass.updateComment(1, "This makes all sense to me!");
        }

        [Test]
        [AllureDescription("delete comment")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task DeleteCommentTest()
        {
            await commentClass.deleteComment("1");
        }



        /********************* Users Test Cases **********************/

        [Test]
        [AllureDescription("Get all users list")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task GetAllUsersTest()
        {
            await userClass.getUsers();
        }

        [Test]
        [AllureDescription("Add new user")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task AddUserTest()
        {
            /**
            * It required 3 params
            * first name, last name and age
            */
            await userClass.addUser(
                "Alex",
                "Kumar",
                25
            );
        }

        [Test]
        [AllureDescription("Update user who's id is 2")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task UpdateUserTest()
        {
            /**
            * It required 4 params
            * userId, first name, last name and age
            */
            await userClass.updateUser(
                2,
                "Hellen",
                "Keller",
                27
            );
        }

        [Test]
        [AllureDescription("delete user who's id is 1")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task DeleteUserTest()
        {
            await userClass.deleteUser(1);
        }

        [Test]
        [AllureDescription("Get user's posts")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task GetUserPostsByIdTest()
        {
            await userClass.getUserPostsById(2);
        }

        [Test]
        [AllureDescription("Gert user's todos")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task GetUserToDosByIdTest()
        {
            await userClass.getUserToDosById(2);
        }


        /********************* ToDo Test Cases **********************/

        [Test]
        [AllureDescription("Get all todos")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task GetAllToDosTest()
        {
            await toDoClass.getToDos();
        }

        [Test]
        [AllureDescription("Add new todo")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task AddToDoTest()
        {
            /**
            * It required 3 params
            * todo, completedStatus and userId
            */
            await toDoClass.addToDo(
                "Submit AST project",
                false,
                5
            );
        }

        [Test]
        [AllureDescription("Update todo")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task UpdateTodoTest()
        {
            /**
            * It required 2 params
            * id and status
            */
            await toDoClass.updateToDo(
                2,
                true
            );
        }

        [Test]
        [AllureDescription("Delete todo by id 1")]
        [AllureOwner("AST Project")]
        [AllureTag("regression", "api", "playwright")]
        public async Task DeleteToDoTest()
        {
            await toDoClass.deleteToDo(1);
        }

    }
}