using Subdlaba.BusinessLogic;
using Subdlaba.Services;
using System;
using System.Diagnostics;

namespace Subdlaba
{
    public class Program
    {
        public static readonly TaskTrackerDatabase db = new TaskTrackerDatabase();
        static void Main(string[] args)
        {
            MainLogic logic = new MainLogic(new CustomerService(), new DeveloperService(), new DeveloperTrackerService(), new ProjectService(), new TrackerService(), new TimingService());
            Insert(logic);
            TrackerService trackerLogic = new TrackerService();
            Stopwatch clock = new Stopwatch();
            clock.Start();
            logic.CreateProject("Poneslas");
            logic.ReadTracker();
            logic.UpdateTracker(2, "Process", "Rabota", 2);
            logic.DeleteTracker(2, "Process", "Rabota", 2);
            logic.ProjectTracker();
            logic.CustomerProject();
            clock.Stop();
            Console.WriteLine(clock.ElapsedMilliseconds);

        }
        public static void Insert(MainLogic logic)
        {
            logic.CreateCustomer("Kim Jong Un", "kndr@mail.ru", 1);
            logic.CreateCustomer("Volk", "goflex@gmail.com", 2);

            logic.CreateDeveloper("Bandit", "Admin");
            logic.CreateDeveloper("Tyler", "The Creator");

            logic.CreateDeveloperTracker(1, 2);
            logic.CreateDeveloperTracker(1, 2);

            logic.CreateProject("Bonk");
            logic.CreateProject("Den sna");

            logic.CreateTiming(DateTime.Parse("08.08.2008"), DateTime.Parse("08.08.2009"), 1);
            logic.CreateTiming(DateTime.Parse("02.02.2020"), DateTime.Parse("11.11.2020"), 2);

            logic.CreateTracker("Paid", "Create database", 1);
            logic.CreateTracker("Closed", "Write", 2);

        }
    }
}
