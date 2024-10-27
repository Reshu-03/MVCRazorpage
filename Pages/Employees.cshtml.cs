using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Data;
using RazorPage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPage.Pages // Update this line if needed
{
    public class EmployeesModel : PageModel
    {
        private readonly RazDbContext _context;

        public EmployeesModel(RazDbContext context)
        {
            _context = context;
            Employees = new List<Employee>();
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee(); // Initialize to avoid null reference

        public IList<Employee> Employees { get; set; }

        // GET: Fetch all employees
        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }

        // GET: Fetch an employee for editing by ID
        public async Task<IActionResult> OnGetEditAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            Employee = employee; // Assign after null-check
            Employees = await _context.Employees.ToListAsync(); // Refresh list for display
            return Page();
        }

        // POST: Add or update employee
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add or update based on whether ID is 0 (new) or not
            if (Employee.Id == 0)
            {
                _context.Employees.Add(Employee);
            }
            else
            {
                _context.Employees.Update(Employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // POST: Delete employee by ID
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
