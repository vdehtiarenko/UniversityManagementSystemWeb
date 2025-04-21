namespace ApplicationCore.Entities
{
    public class Group
    {
        public Guid GroupId { get; set; }

        public string Name { get; set; } = "";

        public Guid CourseId { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Group()
        {
            Students = new List<Student>();
        }

        public Group(Guid id, string name, Guid courseId)
        {
            GroupId = id;
            Name = name;
            CourseId = courseId;
        }
    }
}
