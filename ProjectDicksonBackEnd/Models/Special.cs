using System;
using System.Diagnostics.CodeAnalysis;
using TimeZoneConverter;


namespace ProjectDicksonBackEnd.Models
{
    public class Special
    {
        public string Id { get; set; }
        public string Day { get; set; }
        public string BarName { get; set; }
        public string CategoryName { get; set; }
        public string DrinkName { get; set; }
        public string Price { get; set; }
        public int DayofWeek { get; set; }


        public void setDayOfWeekOrder()
        {
            DateTime now = DateTime.UtcNow.AddHours(-8);
            int currentDay = (int)now.DayOfWeek;

            int day = 0;

            switch (Day)
            {
                case "Sunday": day = 0; break;
                case "Monday": day = 1; break;
                case "Tuesday": day = 2; break;
                case "Wednesday": day = 3; break;
                case "Thursday": day = 4; break;
                case "Friday": day = 5; break;
                case "Saturday": day = 6; break;
            }

            DayofWeek = (day - currentDay + 7) % 7;
        }
    }
}
