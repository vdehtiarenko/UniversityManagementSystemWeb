using ApplicationCore.Entities;
using System.Collections.ObjectModel;

namespace ApplicationCore.Interfaces
{
    public interface ICourseService
    {
        public ObservableCollection<Course> GetAllCourses();

        public Course GetCourseById(Guid courseId);
    }
}
