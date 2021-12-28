using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private ProjectContext db;

        public TaskRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Task> GetAll()
        {
            return db.Tasks;
        }

        public Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public void Create(Task task)
        {
            db.Tasks.Add(task);
        }

        public void Update(Task task)
        {
            db.Tasks.Update(task);
        }

        public IEnumerable<Task> Find(Func<Task, Boolean> predicate)
        {
            return db.Tasks.Where(predicate);
        }

        public void Delete(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task != null)
                db.Tasks.Remove(task);
        }
    }
}
