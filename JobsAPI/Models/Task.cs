using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobsAPI.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public bool Completed { get; set; }
        [Required]
        public int ParentJobId { get; set; }
        
        public DateTime CreatedAt { get; set; }

        
                
        //public Task(int id, string name, int weight, bool completed,int parentJobId)
        //{
        //    Id = id;
        //    Name = name;
        //    Weight = weight;
        //    Completed = completed;
        //    ParentJobId = parentJobId;
        //    CreatedAt = DateTime.Now;
        //}

        public Task(int id, string name, int weight, bool completed, int parentJobId, String createdAt)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Completed = completed;
            ParentJobId = parentJobId;
            CreatedAt = DateTime.Parse(createdAt);
        }
    }
}