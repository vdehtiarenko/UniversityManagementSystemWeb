namespace ApplicationCore.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }

        public string Name { get; set; } = "";

        public string? Description { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public Course(Guid courseId, string name, string? description)
        {
            CourseId = courseId;
            Name = name;
            Description = description;
        }
    }
}

