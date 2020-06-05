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
        public void ReadPage(int strCount, int strSkip)
        {
            var _event = from n in db.Projects.Skip(strSkip).Take(strCount)
                         select new
                         {
                             n.Id,
                             n.Name
                         };
            foreach (var c in _event)
            {
                Console.WriteLine(c.Name);
            }
        }

        public Project Get(int Id)
        {
            return db.Projects.FirstOrDefault(c => c.Id == Id);
        }
        public void CreateProject(string Name)
        {
            Project project = new Project()
            {
                Name = Name
            };
            Create(project);
        }
        public void DeleteProject(int Id, string Name)
        {
            Project project = new Project()
            {
                Id = Id,
                Name = Name
            };
            Delete(project);
        }

        public void UpdateProject(int Id, string Name)
        {
            Project project = new Project()
            {
                Id = Id,
                Name = Name
            };
            Update(project);
        }
        public void ReadProject()
        {
            foreach (var p in Read())
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
