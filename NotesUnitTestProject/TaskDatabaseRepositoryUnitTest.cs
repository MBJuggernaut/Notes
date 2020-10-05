using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesWindowsFormsApp;

namespace NotesUnitTestProject
{
    [TestClass]
    public class TaskDatabaseRepositoryUnitTest
    {
        IServiceCollection services = new ServiceCollection();
        IServiceProvider provider;
        public TaskDatabaseRepositoryUnitTest()
        {
            services.AddSingleton(new TaskContext());
            provider = services.BuildServiceProvider();
        }
        //Arrange
        //Act
        //Assert

        [TestMethod]
        public void Add_OneTask_TaskAdded()
        {
            //Arrange
            var repository = new TaskDatabaseRepository(provider);
            var date = DateTime.Today;
            var taskToAdd = new Task
            {
                Time = "00:00",
                Alarming = "00 мин.",
                Text = "Comment",
                Repeating = "Один раз",
                FirstDate = date
            };

            //Act

            repository.Add(taskToAdd);

            //Assert

            var tasksfordate = repository.GetByDate(date);
            var ourtask = tasksfordate.FirstOrDefault(t => t.Text == "Comment");

            Assert.IsNotNull(ourtask);
        }

        [TestMethod]
        public void Delete_AddThenDeleteOneTask_TaskDeleted()
        {
            //Arrange
            var repository = new TaskDatabaseRepository(provider);
            var date = DateTime.Today;
            var taskToAdd = new Task
            {
                Time = "12:00",
                Alarming = "00 мин.",
                Text = "This should be deleted",
                Repeating = "Один раз",
                FirstDate = date
            };

            //Act

            repository.Add(taskToAdd);

            var tasksfordate = repository.GetByDate(date);
            var tasktodelete = tasksfordate.FirstOrDefault(t => t.Text == taskToAdd.Text);

            repository.Delete(tasktodelete.Id);

            //Assert

            tasksfordate = repository.GetByDate(date);
            tasktodelete = tasksfordate.FirstOrDefault(t => t.Text == taskToAdd.Text);

            Assert.IsNull(tasktodelete);
        }

        [TestMethod]
        public void Update()
        {
            //Arrange

            var repository = new TaskDatabaseRepository(provider);
            var date = DateTime.Today;
            var taskToAdd = new Task
            {
                Time = "00:00",
                Alarming = "00 мин.",
                Text = "This should be changed",
                Repeating = "Один раз",
                FirstDate = date
            };

            var newTask = new Task
            {
                Time = "02:00",
                Alarming = "5 мин.",
                Text = "This should be as result",
                Repeating = "Один раз",
                FirstDate = date
            };

            //Act

            repository.Add(taskToAdd);

            var tasktochange = repository.GetByDate(date).FirstOrDefault(t => t == taskToAdd);

            newTask.Id = tasktochange.Id;

            repository.Update(newTask);

            //Assert
            
            var ourtask = repository.GetByDate(date).FirstOrDefault(t => t.Id == tasktochange.Id);
           
            Assert.IsNotNull(ourtask);

            Assert.AreEqual(ourtask.Time, "02:00");
            Assert.AreEqual(ourtask.Alarming, "5 мин.");
            Assert.AreEqual(ourtask.Text, "This should be as result");          

        }
    }
}
