using System;
using System.Collections.Generic;

namespace HolyChildhood.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }
    }

    public class Event
    {
        public int Id { get; set; }
        public Calendar Calendar { get; set; }
        public string Title { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool AllDay { get; set; }
        public bool Repeats { get; set; }
        public MassEvent MassEvent { get; set; }
        public MeetingEvent MeetingEvent { get; set; }
        public VolunteerEvent VolunteerEvent { get; set; }
    }

    public class MassEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string FirstReading { get; set; }
        public string SecondReading { get; set; }
        public string Gospel { get; set; }
        public string Intentions { get; set; }
        public List<ParishionerMassEvent> Ministers { get; set; }
    }

    public class Minister
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class ParishionerMassEvent
    {
        public int Id { get; set; }
        public int MassEventId { get; set; }
        public MassEvent MassEvent { get; set; }

        public int ParishionerId { get; set; }
        public Parishioner Parishioner { get; set; }

        public int MinisterId { get; set; }
        public Minister Minister { get; set; }
    }

    public class MeetingEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string Agenda { get; set; }
        public string Minutes { get; set; }
    }

    public class VolunteerEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        //public List<Parishioner> Volunteers { get; set; }
    }
}