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
        public void ReadPage(int strCount, int strSkip)
        {
            var _event = from n in db.Timings.Skip(strSkip).Take(strCount)
                         select new
                         {
                             n.Id,
                             n.StartTask,
                             n.FinishTask
                         };
            foreach (var c in _event)
            {
                Console.WriteLine(c.StartTask + " " + c.FinishTask);
            }
        }

        public Timing Get(int Id)
        {
            return db.Timings.FirstOrDefault(c => c.Id == Id);
        }
        public void CreateTiming(DateTime StartTask, DateTime FinishTask, int TrackerId)
        {
            Timing timing = new Timing()
            {
                StartTask = StartTask,
                FinishTask = FinishTask,
                TrackerId = TrackerId
            };
            Create(timing);
        }
        public void DeleteTiming(int Id, DateTime StartTask, DateTime FinishTask, int TrackerId)
        {
            Timing timing = new Timing()
            {
                Id = Id,
                StartTask = StartTask,
                FinishTask = FinishTask,
                TrackerId = TrackerId
            };
            Delete(timing);
        }

        public void UpdateTiming(int Id, DateTime StartTask, DateTime FinishTask, int TrackerId)
        {
            Timing timing = new Timing()
            {
                Id = Id,
                StartTask = StartTask,
                FinishTask = FinishTask,
                TrackerId = TrackerId
            };
            Update(timing);
        }
        public void ReadTiming()
        {
            foreach (var p in Read())
            {
                Console.WriteLine(p.StartTask + " " + p.FinishTask + " " + p.TrackerId);
            }
        }
    }
}
