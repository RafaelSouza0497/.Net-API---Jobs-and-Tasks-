using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobsAPI.Controllers;
using JobsAPI.Models;
using Google.Rpc;

namespace JobsAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        
        JobsController JobController = new JobsController();
        TasksController TasksController = new TasksController();
       
        [TestInitialize]
        public void InitializeTests()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JobCreateParentNull()//testa se o Parent job nao esta setado como null
        {
            Job job = new Job(25, "Job de teste", true, null);
            JobController.PostJob(job);
           

            //Assert.Fail("Fail expected");

           
        }
        [TestMethod]    
        public void JobCreateSelfDependenci()//testa se o Job inserido tem dependencia dele mesmo
        {
            try
            {
                Job job = new Job(25, "Job de teste", true, new Job(25, "Job de teste", true, null));
                JobController.PostJob(job);
            }
            catch (Exception ex)//O job nao pode ter dependencia dele msm
            {
                throw (ex.InnerException);
            }

           
        }
        [TestMethod]
        public void JobCreateEmptyName()//testa se o Job esta com nome vazio
        {
            try
            {
                Job job = new Job(25, string.Empty, true, new Job(25, "Job de teste", true, null));
                JobController.PostJob(job);
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }


        }

        [TestMethod]
        public void JobCreateIdLessThanZero()//testa se o Job esta com nome vazio
        {
            try
            {
                Job job = new Job(int.MinValue, string.Empty, true, new Job(25, "Job de teste", true, null));
                JobController.PostJob(job);
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }


        }
        //new Task(int.MinValue, "Task de Teste", 10, false, 5,"2020 - 05 - 29T00: 00:00"));
       
        [TestMethod]
        public void TaskCreateEmptyName()//testa se o Job esta com nome vazio
        {
            try
            {
                Task task = new Task(40, string.Empty, 10, false, 5, "2020 - 05 - 29T00: 00:00");
                TasksController.PostTask(task);
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }


        }

        [TestMethod]
        public void TaskCreateIdLessThanZero()//testa se o Job esta com nome vazio
        {
            try
            {
                Task task = new Task(int.MinValue,"Task de Teste", 10, false, 5, "2020 - 05 - 29T00: 00:00");
                TasksController.PostTask(task);
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }


        }
        [TestCleanup]
        public void FinishTests()
        {

        }
    }
}
