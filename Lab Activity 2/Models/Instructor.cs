using System;

namespace Lab_Activity_2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TenureStatus TenureStatus { get; set; }
        public Rank Rank { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
    }

    public enum Rank
    {
        Instructor,
        AssistantProfessor,
        AssociateProfessor,
        Professor
    }

    public enum TenureStatus
    {
        Probationary,
        Permanent
    }
}

