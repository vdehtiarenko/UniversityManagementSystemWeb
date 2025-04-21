using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IActionResult Index(Guid courseId, Guid? groupId = null)
        {
            var groups = _groupService.GetCourseGroups(courseId);
            ViewBag.courseId = courseId;
            ViewBag.groupId = groupId;

            return View(groups);
        }

        public IActionResult GetStudents(Guid groupId, Guid courseId)
        {
            var students = _groupService.GetStudentsByGroup(groupId);

            ViewBag.CourseId = courseId;

            return PartialView("_StudentTable", students); 
        }

        public IActionResult Create(Guid courseId)
        {
            var groupDto = new GroupDto
            {
                CourseId = courseId
            };

            return View(groupDto);
        }

        [HttpPost]
        public IActionResult Create(GroupDto groupDto)
        {
            if(!ModelState.IsValid)
            {
                return View(groupDto);
            }

            _groupService.GetOrCreate(groupDto.Name, groupDto.CourseId);

            TempData["SuccessMessage"] = $"The group {groupDto.Name} has been successfully created!";

            return RedirectToAction("Index", "Group", new { groupDto.CourseId });
        }

        public IActionResult Edit(Guid courseId, Guid groupId)
        {
            var group = _groupService.GetGroupById(groupId);

            var groupDto = new GroupDto
            {
                CourseId = courseId,
                GroupId = groupId,
                Name = group.Name
            };
            
            return View(groupDto);
        }

        [HttpPost]
        public IActionResult Edit(GroupDto groupDto)
        {
            _groupService.UpdateGroup(groupDto.GroupId, groupDto.Name);

            return RedirectToAction("Index", "Group", new { groupDto.CourseId, groupDto.GroupId });
        }

        public IActionResult Delete(Guid courseId, Guid groupId)
        {
            try
            {
                _groupService.DeleteGroup(groupId);
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Group", new { courseId });
            }

            return RedirectToAction("Index", "Group", new { courseId });
        }
    }
}
    