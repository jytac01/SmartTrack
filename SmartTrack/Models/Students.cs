﻿namespace SmartTrack.Models
{
    public class Students
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Enrolled { get; set; }
    }
}
