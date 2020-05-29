using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Http.Description;
using JobsAPI.Models;
using Xunit.Sdk;

namespace JobsAPI.Controllers
{
    public class JobsController : ApiController
    {
        private Context db = new Context();
        public Utils Metod = new Utils();

        // GET: api/Jobs
        public List<Job> Get()
        {
            List<Job> Jobs = new List<Job>();
            Jobs = db.Jobs.ToList();

            Metod.TaskByJob(Jobs);//Ordena as Tasks pelo maior tamanho
          

            return Jobs.OrderByDescending(t=>t.Tasks.Sum(w=>w.Weight)).ToList();//Retorna Classificados pela soma de peso das tarefas em um Job. O valor mais alto primeiro.

        }
        
        
        // GET: api/Jobs/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult GetJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJob(int id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.Id)
            {
                return BadRequest();
            }
            if (job.ParentJob.Id.Equals(job.Id))
            {
                return BadRequest("ERRO - Um job não pode ter dependencia dele mesmo!!");
            }
            db.Entry(job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        [ResponseType(typeof(Job))]
        public IHttpActionResult PostJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (job.ParentJob == null)
            {
                throw new ArgumentNullException("O parent Job nao pode ser Nulo");
            }
            if (job.ParentJob.Id.Equals(job.Id))
            {
               
                return BadRequest("ERRO - Um job não pode ter dependencia dele mesmo!!");
                throw new Exception("ERRO - Um job não pode ter dependencia dele mesmo");
            }
            if (string.IsNullOrEmpty(job.name))
            {
                return BadRequest("ERRO - O nome não pode ser Vazio!!");
                throw new Exception("ERRO - Um job não pode ter nome vazio");
            }
            if(job.Id < 0)
            {
                return BadRequest("ERRO - O id tem que ser maior ou igual a 0 !!");
                throw new Exception("ERRO - Um job não pode ter Id menor do que 0");
            }

            db.Jobs.Add(job);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = job.Id }, job);
        }

        // DELETE: api/Jobs/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult DeleteJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            Metod.DependenciJobDelete(job);//Limpa as dependencias entre Jobs

            db.Jobs.Remove(job);
           
            db.SaveChanges();

            return Ok(job);
        }

        //public void DependenciJobDelete(Job job)
        //{

        //    var J = (from j in db.Jobs
        //             where j.ParentJob.Id.Equals(job.Id)
        //             select j);

        //    List<Job> Trabalhos = J.ToList();
           

        //    foreach(Job j in J)
        //    {
        //        j.ParentJob = null;
        //        PutJob(j.Id, job);
        //    }
           
           
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(int id)
        {
            return db.Jobs.Count(e => e.Id == id) > 0;
        }
    }
}