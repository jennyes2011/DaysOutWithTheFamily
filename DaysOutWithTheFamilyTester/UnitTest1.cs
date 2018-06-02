using DaysOutWithTheFamily.Models;
using DaysOutWithTheFamily.Models.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DaysOutWithTheFamilyTester
{
    [TestClass]
    public class TestIndex
    {
        [TestMethod]
        public void IndexReturnsThreePosts()
        {
            //Initialise
            Mock<iPostRepository> mockPosts = new Mock<iPostRepository>();

            mockPosts.Setup(m => m.Read()).Returns(new List<BlogPostModel> {
                new BlogPostModel(){ID=1, Content="testContent1", Created=System.DateTime.Now, SubTitle="subTitle1", Tags=new List<string> {"tag"}, Title="title1"},
                new BlogPostModel(){ID=2, Content="testContent2", Created=System.DateTime.Now, SubTitle="subTitle2", Tags=new List<string> {"tag"}, Title="title2"},
                new BlogPostModel(){ID=3, Content="testContent3", Created=System.DateTime.Now, SubTitle="subTitle3", Tags=new List<string> {"tag"}, Title="title2"}
            });

            
            PostService service = new PostService(mockPosts.Object);

            //Act
            List<BlogPostModel> postsForIndex = service.GetPostsForMainPage();

            //Assert
            Assert.AreEqual(postsForIndex.Count, 3);

        }
    }
}
