using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using Subdlaba.Models;
using Subdlaba.Services;

namespace Subdlaba.BusinessLogic
{
    public class MainLogic
    {
        private readonly CustomerService customerService;
        private readonly DeveloperService developerService;
        private readonly DeveloperTrackerService developerTrackerService;
        private readonly ProjectService projectService;
        private readonly TrackerService trackerService;
        private readonly TimingService timingService;

        public MainLogic(CustomerService customerService, DeveloperService developerService, DeveloperTrackerService developerTrackerService, ProjectService projectService, TrackerService trackerService, TimingService timingService)
        {
            this.trackerService = trackerService;
            this.projectService = projectService;
            this.customerService = customerService;
            this.developerService = developerService;
            this.developerTrackerService = developerTrackerService;
            this.timingService = timingService;
        }

        public MainLogic(CustomerService customerService, DeveloperService developerService, DeveloperTrackerService developerTrackerService, ProjectService projectService, TimingService timingService, TrackerService trackerService)
        {
            this.customerService = customerService;
            this.developerService = developerService;
            this.developerTrackerService = developerTrackerService;
            this.projectService = projectService;
            this.timingService = timingService;
            this.trackerService = trackerService;
        }

        public void CreateCustomer(string Username, string Email, int ProjectId)
        {
            Customer customer = new Customer()
            {
                Username = Username,
                Email = Email,
                ProjectId = ProjectId
            };
            customerService.Create(customer);
        }

        public void CreateDeveloper(string Username, string Working_Role)
        {
            Developer developer = new Developer()
            {
                Username = Username,
                Working_Role = Working_Role
            };
            developerService.Create(developer);
        }

        public void CreateDeveloperTracker(int DeveloperId, int TrackerId)
        {
            DeveloperTracker developerTracker = new DeveloperTracker()
            {
                DeveloperId = DeveloperId,
                TrackerId = TrackerId,
            };
            developerTrackerService.Create(developerTracker);
        }

        public void CreateProject(string Name)
        {
            Project project = new Project()
            {
                Name = Name
            };
            projectService.Create(project);
        }

        public void CreateTiming(DateTime StartTask, DateTime FinishTask, int TrackerId)
        {
            Timing timing = new Timing()
            {
                StartTask = StartTask,
                FinishTask = FinishTask,
                TrackerId = TrackerId
            };
            timingService.Create(timing);
        }

        public void CreateTracker(string Status, string Ticket, int ProjectId)
        {
            Tracker tracker = new Tracker()
            {
                Status = Status,
                Ticket = Ticket,
                ProjectId = ProjectId
            };
            trackerService.Create(tracker);
        }

        public void DeleteCustomer(int Id, string Username, string Email, int ProjectId)
        {
            Customer customer = new Customer()
            {
                Id = Id,
                Username = Username,
                Email = Email,
                ProjectId = ProjectId
            };
            customerService.Delete(customer);
        }

        public void UpdateCustomer(int Id, string Username, string Email, int ProjectId)
        {
            var list = customerService.Get(Id);
            Customer customer = new Customer()
            {
                Id = list.Id,
                Username = Username,
                Email = Email,
                ProjectId = ProjectId
            };
            customerService.Update(customer);
        }

        public void DeleteDeveloper(int Id, string Username, string Working_Role)
        {
            Developer developer = new Developer()
            {
                Id = Id,
                Username = Username,
                Working_Role = Working_Role
            };
            developerService.Delete(developer);
        }

        public void UpdateDeveloper(int Id, string Username, string Working_Role)
        {
            Developer developer = new Developer()
            {
                Id = Id,
                Username = Username,
                Working_Role = Working_Role
            };
            developerService.Update(developer);
        }

        public void DeleteDeveloperTracker(int Id, int DeveloperId, int TrackerId)
        {
            DeveloperTracker developerTracker = new DeveloperTracker()
            {
                Id = Id,
                DeveloperId = DeveloperId,
                TrackerId = TrackerId
            };
            developerTrackerService.Delete(developerTracker);
        }

        public void UpdateDeveloperTracker(int Id, int DeveloperId, int TrackerId)
        {
            DeveloperTracker developerTracker = new DeveloperTracker()
            {
                Id = Id,
                DeveloperId = DeveloperId,
                TrackerId = TrackerId
            };
            developerTrackerService.Update(developerTracker);
        }

        public void DeleteProject(int Id, string Name)
        {
            Project project = new Project()
            {
                Id = Id,
                Name = Name
            };
            projectService.Delete(project);
        }

        public void UpdateProject(int Id, string Name)
        {
            Project project = new Project()
            {
                Id = Id,
                Name = Name
            };
            projectService.Update(project);
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
            timingService.Delete(timing);
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
            timingService.Update(timing);
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
            trackerService.Delete(tracker);
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
            trackerService.Update(tracker);
        }

        public void ReadCustomer()
        {
            var list = customerService.Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Id + " " + p.Username + " " + p.Email + " " + p.ProjectId);
            }
        }

        public void ReadDeveloper()
        {
            var list = developerService.Read();
            foreach (var p in list)
            {
                Console.WriteLine(p.Username + " " + p.Working_Role);
            }
        }

        public void ReadProject()
        {
            foreach (var p in projectService.Read())
            {
                Console.WriteLine(p.Name);
            }
        }


        public void ReadTiming()
        {
            foreach (var p in timingService.Read())
            {
                Console.WriteLine(p.StartTask + " " + p.FinishTask + " " + p.TrackerId);
            }
        }

        public void ReadTracker()
        {
            foreach (var p in trackerService.Read())
            {
                Console.WriteLine(p.Status + " " + p.Ticket + " " + p.ProjectId);
            }
        }
        public void CustomerProject()
        {
            customerService.Zapros_1();
        }
        public void ProjectTracker()
        {
            developerService.Zapros_2();
        }
    }
}
