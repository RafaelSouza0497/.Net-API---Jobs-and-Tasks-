using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobsAPI.Models
{
    public class Context: DbContext
    {
        public Context() : base("Jobs") { }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}