using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerService.Controllers;
using TaskManagerService.ViewModel;

namespace TaskManagerTesting
{
    [TestClass]
    public class TaskManagerTest
    {
        [TestMethod]
        public void Test_AddTask()
        {
            TaskManagerController ctrl = new TaskManagerController();

            TaskDetailsModel task = new TaskDetailsModel();
            task.TaskName = "Task2";
            task.StartDate = DateTime.Now;
            task.EndDate = DateTime.Now.AddDays(15);
            task.IsEnded = false;
            task.ParentTaskName = "Parent Task2";
            task.Priority = 1;

            ctrl.AddTask(task);
        }
        [TestMethod]
        public void Test_ViewTask()
        {
            TaskManagerController ctrl = new TaskManagerController();
            TaskDetailsModel task = new TaskDetailsModel();
            ctrl.ViewTask(task);
        }
        [TestMethod]
        public void Test_UpdateTask()
        {
            TaskManagerController ctrl = new TaskManagerController();

            TaskDetailsModel task = new TaskDetailsModel();
            task.TaskId = 2;
            task.TaskName = "Task2";
            task.StartDate = DateTime.Now;
            task.EndDate = DateTime.Now.AddDays(30);
            task.ParentTaskName = "Parent Task5";
            task.Priority = 1;

            ctrl.UpdateTask(task);
        }
        [TestMethod]
        public void Test_EndTask()
        {
            TaskManagerController ctrl = new TaskManagerController();

            int taskid = 1;

            ctrl.EndTask(taskid);
        }
    }
}