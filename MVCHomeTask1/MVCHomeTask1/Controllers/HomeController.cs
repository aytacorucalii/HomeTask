using Microsoft.AspNetCore.Mvc;
using MVCHomeTask1.Models;

namespace MVCHomeTask1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index1()
    {
        return View();
    }
    public IActionResult Index()
    {
        Student student = new Student()
        {
            Id = 1,
            Name = "Test",
            Surname = "Testov",
            GroupId = 1,
        };
        Student student2 = new Student()
        {
            Id = 2,
            Name = "Testa",
            Surname = "Testova",
            GroupId = 2,
        };
        List<Student> students = new() {student , student2};
        return View(students);
    }
    public IActionResult Index2()
    {
        Teacher teacher = new Teacher()
        {
            Id = 1,
            Name = "Test",

        };
        List<Teacher> teachers = new List<Teacher>() { teacher };
        return View(teacher);
    }
    public JsonResult Index3()
    {
        Group group = new Group()
        {
            Id = 1,
            Name = "Test",

        };
        JsonResult jsonResult = new JsonResult(group);
        return jsonResult;
    }
}
