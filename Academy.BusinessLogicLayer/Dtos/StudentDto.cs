using Academy.DataAccessLayer.Models;

namespace Academy.BusinessLogicLayer.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GroupName { get; set; }
        public int GroupId { get; set; }
    }

    public class CreateStudentDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int GroupId { get; set; }
    }

    public class UpdateStudentDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int GroupId { get; set; }
    }
}
