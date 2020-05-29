using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JobsAPI.Models;

namespace JobsAPI.Controllers
{
    public class TasksController : ApiController
    {
        private Context db = new Context();

        // GET: api/Tasks
        public IQueryable<Task> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(task.Name))
            {
                return BadRequest("ERRO - O nome não pode ser Vazio!!");
                throw new Exception("ERRO - Uma task não pode ter nome vazio");
            }
            if (task.Id < 0)
            {
                return BadRequest("ERRO - O id tem que ser maior ou igual a 0 !!");
                throw new Exception("ERRO - Uma task não pode ter Id menor do que 0");
            }
            db.Tasks.Add(task);
            Job job=new Job();
            //Tenta encontrar o job que é parente da task que esta sendo inserida
           
            if (job == db.Jobs.Find(task.ParentJobId))//Caso encontre um Job compativel com o Id
            {
                job.Tasks.Add(task);//Adiciona a task a lista de tasks do Job
            }
            
            
            db.Entry(job).State = EntityState.Modified;
          
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = task.Id }, task) ;
        }
       
        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.Id == id) > 0;
        }
    }
}