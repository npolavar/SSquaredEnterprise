using Microsoft.AspNetCore.Mvc;
using SoftwareEnterprises.Data;
using SoftwareEnterprises.Models;

namespace SoftwareEnterprises.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var roles=_context.Role.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Role role)
        {
            var AlreadyExist = _context.Role.Any(x => x.RoleName == role.RoleName);

            if (AlreadyExist)
            {
                ModelState.AddModelError("RoleName", "Role Name Already Exist");
            }

            if (ModelState.IsValid)
            {
                _context.Role.Add(role);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }
    }
}
