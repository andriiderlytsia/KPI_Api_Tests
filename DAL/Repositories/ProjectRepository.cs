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
    public class ProjectRepository : IRepository<Project>
    {
        private ProjectContext db;

        public ProjectRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }

        public void Create(Project project)
        {
            db.Projects.Add(project);
        }

        public void Update(Project project)
        {
            db.Projects.Update(project);
        }

        public IEnumerable<Project> Find(Func<Project, Boolean> predicate)
        {
            return db.Projects.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Project book = db.Projects.Find(id);
            if (book != null)
                db.Projects.Remove(book);
        }
    }
}
