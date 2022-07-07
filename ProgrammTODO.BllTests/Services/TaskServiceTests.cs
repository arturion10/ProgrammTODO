using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammTODO.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammTODO.Bll.Services.Tests
{
    [TestClass()]
    public class TaskServiceTests
    {
        [TestMethod()]
        public void Create_IsCreate()
        {
            //Arrange
            var name = "Какая-то задача";
            var description = Guid.NewGuid().ToString();
            var category = Guid.NewGuid().ToString().Substring(20);
            var deadLine = DateTime.Now.AddDays(5);
            var task = new Models.Task(name, description, category, deadLine);
            var context = new Dal.ApplicationContext();
            var taskService = new TaskService(context);

            //Act
            taskService.Create(task);
            var taskOfContext = context.Tasks.Where(x => x.Id == context.Tasks.Max(t => t.Id)).ToList();

            //Assert
            Assert.AreEqual(task.Name, taskOfContext[0].Name);
            Assert.AreEqual(task.Description, taskOfContext[0].Description);
            Assert.AreEqual(task.Category, taskOfContext[0].Category);
            Assert.AreEqual(task.DeadLineСompleting, taskOfContext[0].DeadLineСompleting);
        }
        //TODO: проверка на валидность входных данных

    }
}