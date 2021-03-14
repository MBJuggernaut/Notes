using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesWindowsFormsApp;
using NotesWindowsFormsApp.Models;
using NotesWindowsFormsApp.Repo;
using System;
using System.Linq;

namespace NotesUnitTestProject
{
    [TestClass]
    public class TaskDatabaseRepositoryTest
    {
        readonly DateTime date = DateTime.Today;
        readonly ITaskRepository repository;
        public TaskDatabaseRepositoryTest()
        {
            IServiceProvider provider = MyContainer.Initialize();
            repository = provider.GetService<ITaskRepository>();
        }

        [TestMethod]
        public void TryToAdd_OneTask_TaskAdded()
        {
            //Arrange                       
            var taskToAdd = new UserTask
            {
                Time = "00:00",
                Alarming = "00 мин.",
                Text = "Comment",
                Repeating = "Один раз",
                FirstDate = date
            };

            //Act

            repository.TryToAdd(taskToAdd);

            //Assert

            var ourtask = repository.GetAll().FirstOrDefault(t => t.Text == "Comment");

            Assert.IsNotNull(ourtask);
            Assert.AreEqual(ourtask.Text, taskToAdd.Text);
        }
        [TestMethod]
        public void TryToAdd_NotValidateableTask_TaskNotAdded()
        {
            //Arrange                       
            var taskToAdd = new UserTask
            {
                Time = "00:00",
                Alarming = "00 мин.",
                Text = "This is not validateable task"
            };

            var taskcount1 = repository.GetAll().Count;
            //Act

            repository.TryToAdd(taskToAdd);

            //Assert

            var taskcount2 = repository.GetAll().Count;
            var ourtask = repository.GetAll().FirstOrDefault(t => t.Text == taskToAdd.Text);

            Assert.IsNull(ourtask);
            Assert.AreEqual(taskcount1, taskcount2);
        }
        [TestMethod]
        public void Delete_AddThenDeleteOneTask_TaskDeleted()
        {
            //Arrange                        
            var taskToAdd = new UserTask
            {
                Time = "12:00",
                Alarming = "00 мин.",
                Text = "This should be deleted",
                Repeating = "Один раз",
                FirstDate = date
            };

            //Act

            repository.TryToAdd(taskToAdd);
            var tasktodelete = repository.GetAll().FirstOrDefault(t => t.Text == taskToAdd.Text);
            repository.Delete(tasktodelete.Id);

            //Assert            
            tasktodelete = repository.GetAll().FirstOrDefault(t => t.Text == taskToAdd.Text);

            Assert.IsNull(tasktodelete);
        }
        [TestMethod]
        public void Delete_DeleteNotExistingTask_CountDidntChange()
        {
            //Arrange                        
            var taskcount1 = repository.GetAll().Count;
            //Act

            repository.Delete(-1);

            //Assert            
            var taskcount2 = repository.GetAll().Count;

            Assert.AreEqual(taskcount1, taskcount2);
        }
        [TestMethod]
        public void Update_AddTaskThenChange_TaskChanged()
        {
            //Arrange

            var taskToAdd = new UserTask
            {
                Time = "00:00",
                Alarming = "00 мин.",
                Text = "This should be changed",
                Repeating = "Один раз",
                FirstDate = date
            };

            var newTask = new UserTask
            {
                Time = "02:00",
                Alarming = "5 мин.",
                Text = "This should be as result",
                Repeating = "Один раз",
                FirstDate = date
            };

            //Act

            repository.TryToAdd(taskToAdd);

            var tasktochange = repository.GetAll().FirstOrDefault(t => t == taskToAdd);

            newTask.Id = tasktochange.Id;

            repository.Update(newTask);

            //Assert

            var ourtask = repository.GetAll().FirstOrDefault(t => t.Id == tasktochange.Id);

            Assert.IsNotNull(ourtask);

            Assert.AreEqual(ourtask.Time, "02:00");
            Assert.AreEqual(ourtask.Alarming, "5 мин.");
            Assert.AreEqual(ourtask.Text, "This should be as result");
        }
        [TestMethod]
        public void Update_AddTaskThenTryToChngeForBadTask_TaskNotChanged()
        {
            //Arrange

            var taskToAdd = new UserTask
            {
                Time = "00:00",
                Alarming = "00 мин.",
                Text = "This shouldn't be changed",
                Repeating = "Один раз",
                FirstDate = date
            };

            var newTask = new UserTask
            {
                Time = "02:00",
                Text = "This shouldn't be as result",
                Repeating = "Один раз",

            };

            //Act

            repository.TryToAdd(taskToAdd);

            var tasktochange = repository.GetAll().FirstOrDefault(t => t == taskToAdd);

            newTask.Id = tasktochange.Id;

            repository.Update(newTask);

            //Assert

            var ourtask = repository.GetAll().FirstOrDefault(t => t.Id == tasktochange.Id);

            Assert.IsNotNull(ourtask);

            Assert.AreEqual(ourtask.Time, "00:00");
            Assert.AreEqual(ourtask.Alarming, "00 мин.");
            Assert.AreEqual(ourtask.Text, "This shouldn't be changed");
        }
        [TestMethod]
        public void GetTodayAlerts_AddThenGetTodayAlert_NotNull()
        {
            //Arrange

            var taskToAdd = new UserTask
            {
                Time = "12:00",
                Alarming = "15 мин.",
                Text = "This will be today alarm",
                Repeating = "Один раз",
                FirstDate = date
            };

            //Act

            repository.TryToAdd(taskToAdd);
            var listoftodayalerts = repository.GetTodayAlerts();

            //Assert            

            Assert.IsNotNull(listoftodayalerts);
        }
    }
}
