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
            var tracker = db.Trackers.FirstOrDefault(c => c.Status == model.Status);
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

        public Tracker Get(int Id)
        {
            return db.Trackers.FirstOrDefault(c => c.Id == Id);
        }
    }
}
