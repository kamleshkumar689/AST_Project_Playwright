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
        UserClass userClass = new UserClass();
        ToDoClass toDoClass = new ToDoClass();


        /********************* Posts and Comments Test Cases **********************/
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
        public async Task GetCommentsTest()
        {
            await commentClass.getComments();
        }

        [Test]
        public async Task AddCommentTest()
        {
            await commentClass.addComment("This makes all sense to me!", 3, 5);
        }

        [Test]
        public async Task UpdateCommentTest()
        {
            await commentClass.updateComment(1, "This makes all sense to me!");
        }

        [Test]
        public async Task DeleteCommentTest()
        {
            await commentClass.deleteComment("1");
        }



        /********************* Users Test Cases **********************/

        [Test]
        public async Task GetAllUsersTest()
        {
            await userClass.getUsers();
        }

        [Test]
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
        public async Task DeleteUserTest()
        {
            await userClass.deleteUser(1);
        }

        [Test]
        public async Task GetUserPostsByIdTest()
        {
            await userClass.getUserPostsById(2);
        }

        public async Task GetUserToDosByIdTest()
        {
            await userClass.getUserToDosById(2);
        }


        /********************* ToDo Test Cases **********************/

        [Test]
        public async Task GetAllToDosTest()
        {
            await toDoClass.getToDos();
        }

        [Test]
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
        public async Task DeleteToDoTest()
        {
            await toDoClass.deleteToDo(1);
        }

    }
}