﻿namespace StudentAdminPortal.API.DomainModels
{
    public class StudentAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? PostalAddress { get; set; }

    }
}
