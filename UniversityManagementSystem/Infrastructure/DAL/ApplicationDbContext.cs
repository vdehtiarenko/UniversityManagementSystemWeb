using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course(new Guid("b10e1d67-3f77-4a43-9e6f-1cfe8d09fba4"), "Computer Science and Information Technology", "Fundamentals of computer science and modern information technologies."),
                new Course(new Guid("9d28bdbc-cda2-4d4b-b421-16db5de017cf"), "Software Engineering", "Design, development, and maintenance of software systems."),
                new Course(new Guid("e18f0912-62a1-448e-9332-bdb04c3e46b5"), "Cybersecurity", "Principles and practices of protecting systems, networks, and programs from cyber attacks."),
                new Course(new Guid("c5fbb908-4f91-4b1a-a9e6-4df5b1f0f7b4"), "Information Systems and Technology", "Development and management of information systems and digital technologies."),
                new Course(new Guid("8a5fcac4-3e4c-4c66-bd7f-5f2f909d2a4d"), "Artificial Intelligence and Machine Learning", "AI principles, algorithms, and practical applications of machine learning.")
            );

            modelBuilder.Entity<Group>().HasData(
                new Group(new Guid("f06c2b13-5d3c-4bfb-9c8f-81968b1c43b7"), "CS-101", new Guid("b10e1d67-3f77-4a43-9e6f-1cfe8d09fba4")),
                new Group(new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), "SE-201", new Guid("9d28bdbc-cda2-4d4b-b421-16db5de017cf")),
                new Group(new Guid("c80e2b37-2b72-4d7f-8a9f-1a2b73f9f0d1"), "CY-301", new Guid("e18f0912-62a1-448e-9332-bdb04c3e46b5")),
                new Group(new Guid("d67cba09-45a7-4f2b-9c5b-8a0f8d4e6e6f"), "IT-401", new Guid("c5fbb908-4f91-4b1a-a9e6-4df5b1f0f7b4")),
                new Group(new Guid("b82f93c2-6e1b-4a66-b3c1-3a6f34f1d6d7"), "AI-501", new Guid("8a5fcac4-3e4c-4c66-bd7f-5f2f909d2a4d"))
            );

            modelBuilder.Entity<Student>().HasData(
                new Student("Alice", "Johnson", new Guid("f06c2b13-5d3c-4bfb-9c8f-81968b1c43b7"), new Guid("b6a3c8f5-3a4f-4c66-8a4b-5d2f9f1c6a1a")),
                new Student("Bob", "Smith", new Guid("f06c2b13-5d3c-4bfb-9c8f-81968b1c43b7"), new Guid("d2b1f9e2-8a0f-4a7b-9c5b-6e4e6f8d3c5b")),
                new Student("Charlie", "Davis", new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), new Guid("e3f9d6b2-7c5b-4a0f-8a9b-1a2f4e7b9d6c")),
                new Student("Dave", "Wilson", new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), new Guid("c7d6f8b9-4a0f-5b7c-2b1a-6e9b4e7f3c2d")),
                new Student("Eve", "Taylor", new Guid("fdba714b-5b56-4b07-9e93-541fc57f2b85"), new Guid("f2b1a9b6-4e7b-6c5d-3a0f-9d4c2e7f8b5a")),
                new Student("Frank", "Brown", new Guid("c80e2b37-2b72-4d7f-8a9f-1a2b73f9f0d1"), new Guid("a9b6f7c5-2b1a-4e7d-3a0f-6e9c2f4d8b5a")),
                new Student("Grace", "Miller", new Guid("c80e2b37-2b72-4d7f-8a9f-1a2b73f9f0d1"), new Guid("f4e7c5b6-2b1a-3a0f-9d6e-9b4d8b5a7f2b")),
                new Student("Henry", "Clark", new Guid("d67cba09-45a7-4f2b-9c5b-8a0f8d4e6e6f"), new Guid("d9f8b7c6-4a0f-2b1a-6e7d-3c4e5f9a8b5b")),
                new Student("Ivy", "Moore", new Guid("d67cba09-45a7-4f2b-9c5b-8a0f8d4e6e6f"), new Guid("e7b9c6f5-2a1a-4d3c-0f6e-8b5a7f4b9d6c")),
                new Student("Jack", "Evans", new Guid("b82f93c2-6e1b-4a66-b3c1-3a6f34f1d6d7"), new Guid("f8c7b6a9-2b1a-4d3c-0f6e-5b4e7f9d6a5b")),
                new Student("Kate", "Adams", new Guid("b82f93c2-6e1b-4a66-b3c1-3a6f34f1d6d7"), new Guid("a6b7c8d9-2f1a-4e3d-0b5f-7f4e9d5c6a8b"))
            );


            modelBuilder.Entity<Group>()
                .HasOne<Course>()
                .WithMany(c => c.Groups)
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne<Group>()
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public ApplicationDbContext() : base(new DbContextOptions<ApplicationDbContext>()) { }
    }
}
