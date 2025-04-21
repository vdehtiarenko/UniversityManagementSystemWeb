using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IStudentService
    {
        public Student GetOrCreate(string firstName, string lastName, Guid groupId);

        public Student UpdateStudent(Guid studentId, string firstName, string lastName);

        public void DeleteStudent(Guid studentId);

        public Student GetStudentById(Guid studentId);
    }
}
