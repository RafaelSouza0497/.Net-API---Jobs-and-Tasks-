using JobsAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace JobsAPI.Models
{
    public class Utils
    {
        private Context db = new Context();
        public void TaskByJob(List<Job> Jobs)
        {
            List<Task> tasks = new List<Task>();
            foreach (Job job in Jobs)
            {

                var Tasks = (from task in db.Tasks
                             where task.ParentJobId.Equals(job.Id)
                             select task);
                tasks = Tasks.ToList();
                IEnumerable<Task> query = tasks.OrderByDescending(t => t.Weight);
                job.Tasks = query.ToList();

            }

        }
      
        public void DependenciJobDelete(Job job)
        {
            JobsController control = new JobsController();

            var J = (from j in db.Jobs
                     where j.ParentJob.Id.Equals(job.Id)
                     select j);

            List<Job> Trabalhos = J.ToList();


            foreach (Job j in J)
            {
                j.ParentJob = null;
                control.PutJob(j.Id, job);
            }


        }
    }
}