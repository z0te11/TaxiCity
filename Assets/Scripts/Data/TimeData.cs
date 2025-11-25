    public class TimeData
    {
        public int year;
        public int season; // 0-3: Spring, Summer, Autumn, Winter
        public int day;
        public int hour;
        public int minute;
        
        public TimeData(int newYear, int newSeason, int newDay, int newHour, int newMinute)
        {
            year = newYear;
            season = newSeason;
            day = newDay;
            hour = newHour;
            minute = newMinute;
        }
        public string GetSeasonName()
        {
            return season switch
            {
                0 => "Spring",
                1 => "Summer", 
                2 => "Autumn",
                3 => "Winter",
                _ => "Unknown"
            };
        }
    }
