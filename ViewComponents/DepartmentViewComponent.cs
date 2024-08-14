using Microsoft.AspNetCore.Mvc;
using MVCWithRazor.Interfaces;

namespace MVCWithRazor.ViewComponents
{
    public class DepartmentViewComponent:ViewComponent
    {
        private readonly IDepartment _department;

        public DepartmentViewComponent(IDepartment department)
        {
            _department = department;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _department.GetAll());
        }
    }
}
