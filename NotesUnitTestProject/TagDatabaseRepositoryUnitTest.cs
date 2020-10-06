using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesWindowsFormsApp;
using System;
using System.Linq;

namespace NotesUnitTestProject
{
    [TestClass]
    public class TagDatabaseRepositoryUnitTest
    {
        readonly IServiceCollection services = new ServiceCollection();
        readonly IServiceProvider provider;
        readonly TagDatabaseRepository repository;
        public TagDatabaseRepositoryUnitTest()
        {
            services.AddSingleton(new TaskContext());
            provider = services.BuildServiceProvider();
            repository = new TagDatabaseRepository(provider);
        }       
        [TestMethod]
        public void Add_OneTag_AddedTagToDataBase()
        {
            //Arrange            
            var tag = new Tag() { Text = "test" };
            //Act
            repository.Add(tag);
            //Assert

            var alltags = repository.GetAll();
            var ourtag = alltags.FirstOrDefault(t => t.Text == tag.Text);
            Assert.IsNotNull(alltags);
            Assert.IsNotNull(ourtag);
            Assert.AreNotEqual(Guid.Empty, ourtag.Id);
        }
        [TestMethod]
        public void FindByText_Existingtext_NotNull()
        {
            //Arrange            
            var tag = new Tag() { Text = "Работа" };
            //Act
            tag = repository.FindByText(tag.Text);
            //Assert

            Assert.IsNotNull(tag);
        }
        [TestMethod]
        public void FindByText_NotExistingText_Null()
        {
            //Arrange
            
            var tag = new Tag() { Text = "2574" };
            //Act
            tag = repository.FindByText(tag.Text);
            //Assert
            Assert.IsNull(tag);
        }
        [TestMethod]
        public void GetAll()
        {
            //Arrange
            repository.Add(new Tag { Text = "To fill" });
            
            //Act
            var alltags = repository.GetAll();
            //Assert

            Assert.IsNotNull(alltags);
        }
        [TestMethod]
        public void Delete_OneTag_TagDeleted()
        {
            //Arrange            
            var tag = new Tag() { Text = "tagtodelete" };
            repository.Add(tag);
            var count1 = repository.GetAll().Count;
            //Act
            repository.Delete(tag.Text);

            //Assert
            var count2 = repository.GetAll().Count;
            Assert.IsNull(repository.FindByText(tag.Text));
            Assert.AreEqual(count1, count2 + 1);
        }
        [TestMethod]
        public void Delete_NotExistingTag_NothingHappens()
        {
            //Arrange            
            var tag = new Tag() { Text = "2574" };

            var count1 = repository.GetAll().Count;

            //Act
            repository.Delete(tag.Text);

            //Assert
            var count2 = repository.GetAll().Count;
            Assert.IsNull(repository.FindByText(tag.Text));
            Assert.AreEqual(count1, count2);
        }        
        //Arrange
        //Act
        //Assert
    }
}
