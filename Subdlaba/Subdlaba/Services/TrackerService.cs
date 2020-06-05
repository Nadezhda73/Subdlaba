using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subdlaba.Interface;
using Subdlaba.Models;
using Microsoft.EntityFrameworkCore;

namespace Subdlaba.Services
{
    public class TrackerService : ILogic<Tracker>
    {
        private static TaskTrackerDatabase db = Program.db;

        public void Create(Tracker model)
        {
            var tracker = db.Trackers.FirstOrDefault(c => c.ProjectId == model.ProjectId);
            if (tracker != null)
            {
                throw new Exception("Такой трекер уже есть");
            }
            db.Trackers.Add(model);
            db.SaveChanges();
        }

        public void Delete(Tracker model)
        {
            var tracker = db.Trackers.FirstOrDefault(c => c.Id == model.Id);
            if (tracker == null)
            {
                throw new Exception("Такого трекера нет");
            }
            db.Trackers.Remove(tracker);
            db.SaveChanges();
        }

        public void Update(Tracker model)
        {
            var tracker = db.Trackers.FirstOrDefault(c => c.Id == model.Id);
            if (tracker == null)
            {
                throw new Exception("Такого трекера нет");
            }
            tracker.Status = model.Status;
            tracker.Ticket = model.Ticket;
            tracker.ProjectId = model.ProjectId;
            db.SaveChanges();
        }
        public List<Tracker> Read()
        {
            return db.Trackers.ToList();
        }
        public void ReadPage(int strCount, int strSkip)
        {
            var _event = from n in db.Trackers.Skip(strSkip).Take(strCount)
                         select new
                         {
                             n.Id,
                             n.Status,
                             n.Ticket,
                             n.ProjectId
                         };
            foreach (var c in _event)
            {
                Console.WriteLine(c.Status + " " + c.Ticket + " " + c.ProjectId);
            }
        }

        public Tracker Get(int Id)
        {
            return db.Trackers.FirstOrDefault(c => c.Id == Id);
        }
        public void CreateTracker(string Status, string Ticket, int ProjectId)
        {
            Tracker tracker = new Tracker()
            {
                Status = Status,
                Ticket = Ticket,
                ProjectId = ProjectId
            };
            Create(tracker);
        }

        public void DeleteTracker(int Id, string Status, string Ticket, int ProjectId)
        {
            Tracker tracker = new Tracker()
            {
                Id = Id,
                Status = Status,
                Ticket = Ticket,
                ProjectId = ProjectId
            };
            Delete(tracker);
        }

        public void UpdateTracker(int Id, string Status, string Ticket, int ProjectId)
        {
            Tracker tracker = new Tracker()
            {
                Id = Id,
                Status = Status,
                Ticket = Ticket,
                ProjectId = ProjectId
            };
            Update(tracker);
        }
        public void ReadTracker()
        {
            foreach (var p in Read())
            {
                Console.WriteLine(p.Status + " " + p.Ticket + " " + p.ProjectId);
            }
        }
    }
}
