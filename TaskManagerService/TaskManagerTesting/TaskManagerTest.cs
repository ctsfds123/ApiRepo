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
            task.ParentTaskName = "Task1";

            ctrl.AddTask(task);
        }
        [TestMethod]
        public void Test_ViewTask()
        {
            TaskManagerController ctrl = new TaskManagerController();

            TaskDetailsModel task = new TaskDetailsModel();
            task.ParentTaskName = "Task1";
            
            ctrl.ViewTask(task);
        }
        [TestMethod]
        public void Test_UpdateTask()
        {
            TaskManagerController ctrl = new TaskManagerController();

            TaskDetailsModel task = new TaskDetailsModel();
            task.ParentTaskName = "Task1";

            ctrl.UpdateTask(task);
        }
        [TestMethod]
        public void Test_EndTask()
        {
            TaskManagerController ctrl = new TaskManagerController();

            TaskDetailsModel task = new TaskDetailsModel();
            task.ParentTaskName = "Task1";

            ctrl.EndTask(task.TaskId);
        }
    }
}
