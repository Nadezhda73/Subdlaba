using Subdlaba.Services;
using System;
using System.Diagnostics;

namespace Subdlaba
{
    public class Program
    {
        public static readonly TaskTrackerDatabase db = new TaskTrackerDatabase();
        private static CustomerService customerService;
        private static DeveloperService developerService;
        private static DeveloperTrackerService developerTrackerService;
        private static ProjectService projectService;
        private static TrackerService trackerService;
        private static TimingService timingService;
        static void Main(string[] args)
        {
            TrackerService trackerLogic = new TrackerService();
            Stopwatch clock = new Stopwatch();
            clock.Start();
            projectService.CreateProject("Poneslas");
            trackerService.ReadTracker();
            trackerService.UpdateTracker(2, "Process", "Rabota", 2);
            trackerService.DeleteTracker(2, "Process", "Rabota", 2);
            developerService.ZaprosProjectTracker();
            customerService.ZaprosCustomerProject();
            clock.Stop();
            Console.WriteLine(clock.ElapsedMilliseconds);
            Insert();
        }
        public static void Insert()
        {
            customerService.CreateCustomer("Kim Jong Un", "kndr@mail.ru", 1);
            customerService.CreateCustomer("Volk", "goflex@gmail.com", 2);

            developerService.CreateDeveloper("Bandit", "Admin");
            developerService.CreateDeveloper("Tyler", "The Creator");

            developerTrackerService.CreateDeveloperTracker(1, 2);
            developerTrackerService.CreateDeveloperTracker(1, 2);

            projectService.CreateProject("Bonk");
            projectService.CreateProject("Den sna");

            timingService.CreateTiming(DateTime.Parse("08.08.2008"), DateTime.Parse("08.08.2009"), 1);
            timingService.CreateTiming(DateTime.Parse("02.02.2020"), DateTime.Parse("11.11.2020"), 2);

            trackerService.CreateTracker("Paid", "Create database", 1);
            trackerService.CreateTracker("Closed", "Write", 2);

        }
    }
}
