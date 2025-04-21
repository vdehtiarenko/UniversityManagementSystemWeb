namespace ApplicationCore.DTO
{
    public class StudentDto
    {
        public Guid CourseId { get; set; }

        public Guid GroupId { get; set; }

        public Guid StudentId { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";
    }
}
