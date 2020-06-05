using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subdlaba.Interface;
using Subdlaba.Models;
using Microsoft.EntityFrameworkCore;

namespace Subdlaba.Services
{
    public class DeveloperService : ILogic<Developer>
    {
        private static TaskTrackerDatabase db = Program.db;

        public void Create(Developer model)
        {
            var developer = db.Developers.FirstOrDefault(c => c.Username == model.Username);
            if (developer != null)
            {
                throw new Exception("Такой разработчик уже есть");
            }
            db.Developers.Add(model);
            db.SaveChanges();
        }

        public void Delete(Developer model)
        {
            var developer = db.Developers.FirstOrDefault(c => c.Id == model.Id);
            if (developer == null)
            {
                throw new Exception("Такого разработчика нет");
            }
            db.Developers.Remove(developer);
            db.SaveChanges();
        }

        public void Update(Developer model)
        {
            var developer = db.Developers.FirstOrDefault(c => c.Id == model.Id);
            if (developer == null)
            {
                throw new Exception("Такого разработчика нет");
            }
            developer.Username = model.Username;
            db.SaveChanges();
        }
        public List<Developer> Read()
        {
            return db.Developers.ToList();
        }
        public void ReadPage(int strCount, int strSkip)
        {
            var _event = from n in db.Developers.Skip(strSkip).Take(strCount)
                         select new
                         {
                             n.Id,
                             n.Username,
                             n.Working_Role
                         };
            foreach (var c in _event)
            {
                Console.WriteLine(c.Username + " " + c.Working_Role);
            }
        }

        public Developer Get(int Id)
        {
            return db.Developers.FirstOrDefault(c => c.Id == Id);
        }
        public void ZaprosProjectTracker()
        {
            var project = from p in db.Projects
                          join c in db.Trackers on p.Id equals c.ProjectId
                          join r in db.Timings on p.Id equals r.Id
                          select new { r.StartTask, r.FinishTask, c.Ticket, p.Name };
            foreach (var c in project)
            {
                Console.WriteLine(c.Name + " " + c.Ticket + " " + c.StartTask + " " + c.FinishTask);
            }
        }
        public void CreateDeveloper(string Username, string Working_Role)
        {
            Developer developer = new Developer()
            {
                Username = Username,
                Working_Role = Working_Role
            };
            Create(developer);
        }
        public void DeleteDeveloper(int Id, string Username, string Working_Role)
        {
            Developer developer = new Developer()
            {
                Id = Id,
                Username = Username,
                Working_Role = Working_Role
            };
            Delete(developer);
        }
        public void UpdateDeveloper(int Id, string Username, string Working_Role)
        {
            Developer developer = new Developer()
            {
                Id = Id,
                Username = Username,
                Working_Role = Working_Role
            };
            Update(developer);
        }
        public void ReadDeveloper()
        {
            var list = Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Username + " " + p.Working_Role);
            }
        }
    }
}
