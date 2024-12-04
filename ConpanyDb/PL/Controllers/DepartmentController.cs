using BLL.Interfaces;
using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepositories;

        public DepartmentController(IDepartmentRepository departmentRepositories)
        {
            _departmentRepositories = departmentRepositories;
        }
        public IActionResult Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var employee = _departmentRepositories.GetAll();
                return View(employee);

            }
            else
            {
                var employee = _departmentRepositories.GetEmployeeByName(SearchValue);
                return View(employee);
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                int result = _departmentRepositories.add(department);
                if (result > 0)
                {
                    TempData["Message"] = "Department is Created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id is null)
                return BadRequest();
            var department = _departmentRepositories.GetById(Id.Value);
            if(department is null)
                return NotFound();
            return View(department);
        }

        public IActionResult Edit(int? Id)
        {
            return Details(Id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepositories.update(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult Delete(int? Id)
        {
            return Details(Id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            if(ModelState.IsValid)
            {
                _departmentRepositories.delete(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
    }
}
