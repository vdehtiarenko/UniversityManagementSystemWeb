using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Create(Guid courseId, Guid groupId)
        {
            var studentDto = new StudentDto
            {
                CourseId = courseId,
                GroupId = groupId
            };

            return View(studentDto);
        }

        [HttpPost]
        public IActionResult Create(StudentDto studentDto)
        {
            if(!ModelState.IsValid)
            {
                return View(studentDto);
            }

            _studentService.GetOrCreate(studentDto.FirstName, studentDto.LastName, studentDto.GroupId);

            TempData["SuccessMessage"] = $"The student {studentDto.FirstName} {studentDto.LastName} has been successfully created!";

            return RedirectToAction("Index", "Group", new { studentDto.CourseId, studentDto.GroupId });
        }

        public IActionResult Edit(Guid courseId, Guid groupId, Guid studentId)
        {
            var student = _studentService.GetStudentById(studentId);

            var studentDto = new StudentDto
            {
                CourseId = courseId,
                GroupId = groupId,
                StudentId = studentId,
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            return View(studentDto);
        }

        [HttpPost]
        public IActionResult Edit(StudentDto studentDto)
        {
            _studentService.UpdateStudent(studentDto.StudentId, studentDto.FirstName, studentDto.LastName);

            return RedirectToAction("Index", "Group", new { studentDto.CourseId, studentDto.GroupId });
        }

        public IActionResult Delete(Guid courseId, Guid groupId, Guid studentId)
        {
            _studentService.DeleteStudent(studentId);

            return RedirectToAction("Index", "Group", new { courseId, groupId });
        }
    }
}
