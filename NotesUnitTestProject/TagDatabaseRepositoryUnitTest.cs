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
        IServiceCollection services = new ServiceCollection();
        IServiceProvider provider;
        public TagDatabaseRepositoryUnitTest()
        {
            services.AddSingleton(new TaskContext());
            provider = services.BuildServiceProvider();
        }
        //Arrange
        //Act
        //Assert
        [TestMethod]
        public void Add_OneTag_AddedTagToDataBase()
        {
            //Arrange
            var repository = new TagDatabaseRepository(provider);
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
            var repository = new TagDatabaseRepository(provider);
            var tag = new Tag() { Text = "Работа" };
            //Act
            tag = repository.FindByText(tag.Text);
            //Assert

            Assert.IsNotNull(tag);

        }

        [TestMethod]
        public void GetAll()
        {
            //Arrange
            var repository = new TagDatabaseRepository(provider);
            
            //Act
            var alltags = repository.GetAll();
            //Assert

            Assert.IsNotNull(alltags);
        }

        [TestMethod]
        public void Delete_OneTag_TagDeleted()
        {
            //Arrange
            var repository = new TagDatabaseRepository(provider);
            var tag = new Tag() { Text = "tagtodelete" };
            repository.Add(tag);

            //Act
            repository.Delete(tag);

            //Assert

            Assert.IsNull(repository.FindByText(tag.Text));
        }


    }
}
