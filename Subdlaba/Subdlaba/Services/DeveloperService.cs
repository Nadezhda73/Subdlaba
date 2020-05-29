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

        public Developer Get(int Id)
        {
            return db.Developers.FirstOrDefault(c => c.Id == Id);
        }
        public void Zapros_2()
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
    }
}
