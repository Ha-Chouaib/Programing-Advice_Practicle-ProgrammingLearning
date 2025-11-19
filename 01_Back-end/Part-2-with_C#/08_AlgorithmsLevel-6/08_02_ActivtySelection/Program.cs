using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_02_ActivitySelection
{
    internal class Program
    {

        class clsActivity
        {
            public string ActivityName { get; set; }
            public int StartTime { get; set; }
            public int EndTime { get; set; }
        }
       
        static List<clsActivity> NoneOverlapActivities(List<clsActivity> activities)
        {
            var result = new List<clsActivity>();
            activities.Sort((a, b) => a.EndTime.CompareTo(b.EndTime));

            result.Add(activities.First());
            foreach (var activity in activities.Skip(1))
            { 
                if(activity.StartTime.CompareTo(result.Last().EndTime) > 0)
                {
                    result.Add(activity);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<clsActivity> activities = new List<clsActivity>
            {
                new clsActivity { ActivityName = "Activity 1", StartTime = 1, EndTime = 4 },
                new clsActivity { ActivityName = "Activity 2", StartTime = 3, EndTime = 5 },
                new clsActivity { ActivityName = "Activity 3", StartTime = 0, EndTime = 6 },
                new clsActivity { ActivityName = "Activity 4", StartTime = 5, EndTime = 7 },
                new clsActivity { ActivityName = "Activity 5", StartTime = 8, EndTime = 9 },
                new clsActivity { ActivityName = "Activity 6", StartTime = 5, EndTime = 9 }
            };

                Console.WriteLine("Activities List:\n");
            foreach (var activity in activities)
            {
                Console.WriteLine($"Activity({activity.StartTime}, {activity.EndTime})");
            }

            Console.WriteLine("\nThe maximum set of mutually compatible activities:\n");
            foreach (var activity in NoneOverlapActivities(activities))
            {
                Console.WriteLine($"Activity({activity.StartTime}, {activity.EndTime})");
            }




        }
    }
}
