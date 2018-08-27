using System;

namespace HolyChildhood.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

    }
}