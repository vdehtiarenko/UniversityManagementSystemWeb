using ApplicationCore.Entities;
using System.Collections.ObjectModel;

namespace ApplicationCore.Interfaces
{
    public interface IGroupService
    {
        public Group GetOrCreate(string name, Guid courseId);

        public ObservableCollection<Student> GetStudentsByGroup(Guid groupId);

        public ObservableCollection<Group> GetCourseGroups(Guid courseId);

        public Group UpdateGroup(Guid groupId, string name);

        public void DeleteGroup(Guid groupId);

        public Group GetGroupById(Guid groupId);
    }
}
