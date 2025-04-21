using ApplicationCore.Entities;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Interfaces;
using System.Collections.ObjectModel;

namespace Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ObservableCollection<Course> GetAllCourses()
        {
            var courses =  _dbContext.Courses
                             .AsNoTracking()
                             .OrderBy(c => c.Name)
                             .ToList();

            return new ObservableCollection<Course>(courses);
        }

        public Course GetCourseById(Guid courseId)
        {
            var course = _dbContext.Courses
                                   .FirstOrDefault(c => c.CourseId == courseId);

            if (course == null)
            {
                throw new KeyNotFoundException($"Course with the specified ID not exist.");
            }

            return course;
        }
    }
}
