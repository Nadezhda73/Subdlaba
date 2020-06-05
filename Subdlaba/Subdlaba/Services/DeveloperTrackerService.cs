using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subdlaba.Interface;
using Subdlaba.Models;
using Microsoft.EntityFrameworkCore;

namespace Subdlaba.Services
{
    public class DeveloperTrackerService : ILogic<DeveloperTracker>
    {
        private static TaskTrackerDatabase db = Program.db;

        public void Create(DeveloperTracker model)
        {
            var developerTracker = db.DeveloperTrackers.FirstOrDefault(c => c.Id == model.Id);
            if (developerTracker != null)
            {
                throw new Exception("Такой трекер разработчика уже есть");
            }
            db.DeveloperTrackers.Add(model);
            db.SaveChanges();
        }

        public void Delete(DeveloperTracker model)
        {
            var developerTracker = db.DeveloperTrackers.FirstOrDefault(c => c.Id == model.Id);
            if (developerTracker == null)
            {
                throw new Exception("Такого трекера разработчика нет");
            }
            db.DeveloperTrackers.Remove(developerTracker);
            db.SaveChanges();
        }

        public void Update(DeveloperTracker model)
        {
            var developerTracker = db.DeveloperTrackers.FirstOrDefault(c => c.Id == model.Id);
            if (developerTracker == null)
            {
                throw new Exception("Такого трекера разработчика нет");
            }
            developerTracker.Id = model.Id;
            db.SaveChanges();
        }
        public List<DeveloperTracker> Read()
        {
            return db.DeveloperTrackers.ToList();
        }
        public void ReadPage(int strCount, int strSkip)
        {
            var _event = from n in db.DeveloperTrackers.Skip(strSkip).Take(strCount)
                         select new
                         {
                             n.Id,
                             n.DeveloperId,
                             n.TrackerId
                         };
            foreach (var c in _event)
            {
                Console.WriteLine(c.DeveloperId + " " + c.TrackerId);
            }
        }

        public DeveloperTracker Get(int Id)
        {
            return db.DeveloperTrackers.FirstOrDefault(c => c.Id == Id);
        }
        public void CreateDeveloperTracker(int DeveloperId, int TrackerId)
        {
            DeveloperTracker developerTracker = new DeveloperTracker()
            {
                DeveloperId = DeveloperId,
                TrackerId = TrackerId,
            };
            Create(developerTracker);
        }
        public void DeleteDeveloperTracker(int Id, int DeveloperId, int TrackerId)
        {
            DeveloperTracker developerTracker = new DeveloperTracker()
            {
                Id = Id,
                DeveloperId = DeveloperId,
                TrackerId = TrackerId
            };
            Delete(developerTracker);
        }

        public void UpdateDeveloperTracker(int Id, int DeveloperId, int TrackerId)
        {
            DeveloperTracker developerTracker = new DeveloperTracker()
            {
                Id = Id,
                DeveloperId = DeveloperId,
                TrackerId = TrackerId
            };
            Update(developerTracker);
        }
    }
}
