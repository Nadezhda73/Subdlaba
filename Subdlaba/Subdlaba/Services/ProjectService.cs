using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subdlaba.Interface;
using Subdlaba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Subdlaba.Services
{
    public class ProjectService : ILogic<Project>
    {
        private static TaskTrackerDatabase db = Program.db;

        public void Create(Project model)
        {
            var project = db.Projects.FirstOrDefault(c => c.Name == model.Name);
            if (project != null)
            {
                throw new Exception("Такой проект уже есть");
            }
            db.Projects.Add(model);
            db.SaveChanges();
        }

        public void Update(Project model)
        {
            var project = db.Projects.FirstOrDefault(c => c.Id == model.Id);
            if (project == null)
            {
                throw new Exception("Такого проекта нет");
            }
            project.Name = model.Name;
            db.SaveChanges();
        }

        public void Delete(Project model)
        {
            var project = db.Projects.FirstOrDefault(c => c.Id == model.Id);
            if (project == null)
            {
                throw new Exception("Такого проекта нет");
            }
            db.Projects.Remove(project);
            db.SaveChanges();
        }

        public List<Project> Read()
        {
            return db.Projects.ToList();
        }

        public Project Get(int Id)
        {
            return db.Projects.FirstOrDefault(c => c.Id == Id);
        }
    }
}
