using NBench.Util;
using NBench;
using TaskManagerService.Controllers;
using System;
using TaskManagerService.ViewModel;

namespace TaskManagerLoadTesting
{
    public class NBenchLoadTest
    {
        private TaskManagerController _ctrl;
        private int index = 10;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _ctrl = new TaskManagerController();
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 3, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestAddTask", MustBe.LessThan, 10000000.0d)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void BenchmarkAddTask()
        {
            TaskDetailsModel task = new TaskDetailsModel();
            task.TaskName = "Task" + index.ToString();
            task.StartDate = DateTime.Now;
            task.EndDate = DateTime.Now.AddDays(15);
            task.IsEnded = false;
            task.ParentTaskName = "Parent Task" + index.ToString();
            task.Priority = 1;
            index++;
            _ctrl.AddTask(task);
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestViewTask", MustBe.LessThan, 10000000.0d)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void BenchmarkViewTask()
        {
            TaskDetailsModel task = new TaskDetailsModel();
              
            _ctrl.ViewTask(task);
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestUpdateTask", MustBe.LessThan, 10000000.0d)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void BenchmarkUpdateTask()
        {
            TaskDetailsModel task = new TaskDetailsModel();

            task.TaskId = 2;
            task.TaskName = "Task2" + index.ToString();
            task.StartDate = DateTime.Now;
            task.EndDate = DateTime.Now.AddDays(30);
            task.ParentTaskName = "Parent Task2" + index.ToString();
            task.Priority = 1;
            index++;
            _ctrl.UpdateTask(task);
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
           NumberOfIterations = 3, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestEndTask", MustBe.LessThan, 10000000.0d)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void BenchmarkEndTask()
        {         

            _ctrl.EndTask(index);
            index++;
        }

        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }
    }
}