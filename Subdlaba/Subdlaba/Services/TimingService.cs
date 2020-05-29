using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Subdlaba.Interface;
using Subdlaba.Models;
using Microsoft.EntityFrameworkCore;

namespace Subdlaba.Services
{
    public class TimingService : ILogic<Timing>
    {
        private static TaskTrackerDatabase db = Program.db;

        public void Create(Timing model)
        {
            var timing = db.Timings.FirstOrDefault(c => c.Id == model.Id);
            if (timing != null)
            {
                throw new Exception("Такие сроки уже есть");
            }
            db.Timings.Add(model);
            db.SaveChanges();
        }

        public void Delete(Timing model)
        {
            var timing = db.Timings.FirstOrDefault(c => c.Id == model.Id);
            if (timing == null)
            {
                throw new Exception("Таких сроков нет");
            }
            db.Timings.Remove(timing);
            db.SaveChanges();
        }

        public void Update(Timing model)
        {
            var timing = db.Timings.FirstOrDefault(c => c.Id == model.Id);
            if (timing == null)
            {
                throw new Exception("Таких сроков нет");
            }
            timing.Id = model.Id;
            db.SaveChanges();
        }

        public List<Timing> Read()
        {
            return db.Timings.ToList();
        }

        public Timing Get(int Id)
        {
            return db.Timings.FirstOrDefault(c => c.Id == Id);
        }
    }
}
