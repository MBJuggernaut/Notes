using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        TaskDatabaseRepository repository;
        DateTime date = DateTime.Today;
        public TaskDatabaseRepositoryUnitTest()
        {
            services.AddSingleton(new TaskContext());
            provider = services.BuildServiceProvider();
            repository = new TaskDatabaseRepository(provider);
        }
        //Arrange
        //Act
        //Assert

        [TestMethod]
        public void Add_OneTask_TaskAdded()
        {
            //Arrange                       
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
            
            var ourtask = repository.GetAll().FirstOrDefault(t => t.Text == "Comment");

            Assert.IsNotNull(ourtask);
            Assert.AreEqual(ourtask.FirstDate, date);           
        }

        [TestMethod]
        public void Delete_AddThenDeleteOneTask_TaskDeleted()
        {
            //Arrange                        
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
        public void GetTodayAlerts_AddThenGetTodayAlert_NotNull()
        {
            //Arrange

            var taskToAdd = new Task
            {
                Time = "12:00",
                Alarming = "15 мин.",
                Text = "This will be today alarm",
                Repeating = "Один раз",
                FirstDate = date
            };           

            //Act

            repository.Add(taskToAdd);
            var listoftodayalerts = repository.GetTodayAlerts();            

            //Assert            

            Assert.IsNotNull(listoftodayalerts);            
        }
    }
}
