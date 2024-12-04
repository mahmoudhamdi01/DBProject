using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
             _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index(string SearchValue)
        {
            if(string.IsNullOrEmpty(SearchValue))
            {
            var employee = _employeeRepository.GetAll();
            return View(employee);

            }
            else
            {
                var employee = _employeeRepository.GetEmployeeByName(SearchValue);
                return View(employee);
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int result = _employeeRepository.add(employee);
                if (result > 0)
                {
                    TempData["Message"] = "Employee is Created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Details(int? Id, string iewName = "Details")
        {
            if (Id is null)
                return BadRequest();
            var employee = _employeeRepository.GetById(Id.Value);
            if(employee is null)
                return NotFound();
            return View(employee);
        }

        public IActionResult Edit(int? Id)
        {
            return Details(Id, "Edit");
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.update(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete"); 
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.delete(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

    }
}
