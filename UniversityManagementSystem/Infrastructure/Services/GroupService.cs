using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Infrastructure.Services
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _dbContext;

        public GroupService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Group GetOrCreate(string name, Guid courseId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The group name cannot be empty.");
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentException("The course ID cannot be empty.");
            }

            var existingGroup = _dbContext.Groups
                .FirstOrDefault(g => string.Equals(g.Name.Trim().ToUpper(), name.Trim().ToUpper()));

            if (existingGroup != null)
            {
                return existingGroup;
            }

            var existingCourse = _dbContext.Courses
                .FirstOrDefault(c => c.CourseId == courseId);

            if (existingCourse == null)
            {
                throw new ArgumentException("The specified course does not exist.");
            }
 
            Guid id = Guid.NewGuid();

            var group = new Group(id, name.Trim(), courseId);

            _dbContext.Groups.Add(group);

            _dbContext.SaveChanges();

            return group;
        }

        public ObservableCollection<Student> GetStudentsByGroup(Guid groupId)
        {
            var students = _dbContext.Students
                                      .AsNoTracking()
                                      .Where(s => s.GroupId == groupId)
                                      .OrderBy(s => s.FirstName)
                                      .ThenBy(s => s.LastName)
                                      .ToList();

            return new ObservableCollection<Student>(students);
        }

        public ObservableCollection<Group> GetCourseGroups(Guid courseId)
        {
            var groups = _dbContext.Groups
                .AsNoTracking()
                .Where(g => g.CourseId == courseId)
                .Include(g => g.Students)
                .ToList();

            return new ObservableCollection<Group>(groups);
        }

        public Group UpdateGroup(Guid groupId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The group name cannot be empty.");
            }

            if (groupId == Guid.Empty)
            {
                throw new ArgumentException("The group ID cannot be empty.");
            }

            var existingGroup = _dbContext.Groups.FirstOrDefault(g => g.GroupId == groupId);

            if (existingGroup == null)
            {
                throw new ArgumentException("The specified group was not found.");
            }

            var dublicateGroup = _dbContext.Groups.FirstOrDefault(g => g.Name == name.Trim());

            if (dublicateGroup != null)
            {
                throw new ArgumentException("A group with the same name already exists.");
            }

            existingGroup.Name = name.Trim();

            _dbContext.Groups.Update(existingGroup);

            _dbContext.SaveChanges();

            return existingGroup;
        }

        public void DeleteGroup(Guid groupId)
        {
            if (groupId == Guid.Empty)
            {
                throw new ArgumentException("The group ID cannot be empty.");
            }

            var existingGroup = _dbContext.Groups.FirstOrDefault(g => g.GroupId == groupId);

            if (existingGroup == null)
                throw new ArgumentException("The group cannot be null.");

            var groupStudents = _dbContext.Students
               .Where(s => s.GroupId == groupId)
               .ToList();

            if (groupStudents.Count > 0)
            {
                throw new InvalidOperationException("The group already has assigned students.");
            }

            _dbContext.Groups.Remove(existingGroup);

            _dbContext.SaveChanges();
        }

        public Group GetGroupById(Guid groupId)
        {
            if (groupId == Guid.Empty)
            {
                throw new ArgumentException("The group ID cannot be empty.");
            }

            var group = _dbContext.Groups
                .AsNoTracking()
                .FirstOrDefault(g => g.GroupId == groupId);

            if (group == null)
            {
                throw new ArgumentException("The specified group does not exist.");
            }

            return group;
        }
    }
}
