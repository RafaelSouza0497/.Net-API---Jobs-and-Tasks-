using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobsAPI.Models
{
    public class Job
    {
        [Key]
        public int Id {get;set; }
        [Required]
        public string name { get; set; }
        [Required]
        public bool Active { get; set; }
        
        public Job ParentJob { get; set; }
        public List<Task>Tasks { get; set; }
        public Job()
        {
            Tasks = new List<Task>();
        }

        public Job(int id, string name, bool active, Job parentJob)
        {
            Id = id;
            this.name = name;
            Active = active;
            ParentJob = parentJob;
            Tasks = new List<Task>();
        }
        public Job(int id, string name, bool active)
        {
            Id = id;
            this.name = name;
            Active = active;
           
            Tasks = new List<Task>();
        }
    }
}