using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCWithRazor.Interfaces;
using MVCWithRazor.Models;

namespace MVCWithRazor.Pages.Department
{
    public class IndexModel : PageModel
    {
        private readonly IDepartment _department;

        public IndexModel(IDepartment department)
        {
            _department = department;
        }

        public List<Models.Department> Departments { get; set; }

        public async Task OnGet()
        {
            try
            {
                Departments = await _department.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error retrieving departments: {ex.Message}");
            }
        }
    }
}
