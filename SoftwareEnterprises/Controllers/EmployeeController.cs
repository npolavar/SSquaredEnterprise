using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftwareEnterprises.Data;
using SoftwareEnterprises.Models;


namespace SoftwareEnterprises.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context= context;
        }

        public IActionResult Index()
        {
            var show = _context.Employee.ToList();
            
            ViewBag.Manager = new SelectList(_context.Employee, "Id" , "FullName");
            return View(show);
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            
            ViewBag.Manager = new SelectList(_context.Employee, "Id", "FullName");
            var obj =_context.Employee.Where(e => e.ParentId == id).ToList();

            return View(obj);
        }


        public IActionResult Create()
        {
            ViewBag.Emp = new SelectList(_context.Employee, "Id", "FullName");
            ViewBag.Roles = new SelectList(_context.Role, "Id", "RoleName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee, int EmpNameId, int[] SelectRoles)
        {
            
            Employee emp = new Employee();

            // Display error message when roles field is not selected
            if (SelectRoles.Length == 0)
            {
                ViewBag.message = "Roles is required";

                ViewBag.Emp = new SelectList(_context.Employee, "Id", "FullName");
                ViewBag.Roles = new SelectList(_context.Role, "Id", "RoleName");

                return View(emp);
            }

            var isAlready = _context.Employee.Any(x => x.EmployesId == employee.EmployesId);
           
            // To verify if the employee id already exist or not 
            if (isAlready)
            {
                ModelState.AddModelError("EmployesId", "EmployeesId Already Exist");

                ViewBag.Emp = new SelectList(_context.Employee, "Id", "FullName");
                ViewBag.Roles = new SelectList(_context.Role, "Id", "RoleName");

                return View(employee);
            }
            
            try
            {
                if(EmpNameId == 0)
                {

                    employee.ParentId = emp.ParentId = 0;

                    _context.Employee.Add(employee);

                    _context.SaveChanges();

                    for (int i = 0; i < SelectRoles.Count(); i++)
                    {
                        UserRoles userRoles = new UserRoles();
                        userRoles.EmployeID = employee.Id;
                        userRoles.RoleId = SelectRoles[i];
                        _context.UserRole.Add(userRoles);
                        _context.SaveChanges();
                       
                    }
                    return RedirectToAction("Index");

                }
                else
                {
                    employee.ParentId = emp.ParentId = EmpNameId;
                    _context.Employee.Add(employee);

                    _context.SaveChanges();

                    for (int i = 0; i < SelectRoles.Count(); i++)
                    {
                        UserRoles userRoles = new UserRoles();
                        userRoles.EmployeID = employee.Id;
                        userRoles.RoleId = SelectRoles[i];
                        _context.UserRole.Add(userRoles);
                        _context.SaveChanges();
                      

                    }
                    return RedirectToAction("Index");
                }

            }
            catch(Exception ex)
            {
                return View(ex);
            }

           
        }
    }
}
