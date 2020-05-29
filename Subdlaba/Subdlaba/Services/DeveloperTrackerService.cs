﻿using System;
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

        public DeveloperTracker Get(int Id)
        {
            return db.DeveloperTrackers.FirstOrDefault(c => c.Id == Id);
        }
    }
}