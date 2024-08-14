using Microsoft.AspNetCore.Mvc;

namespace MVCWithRazor.ViewComponents
{
    public class StudentViewComponent:ViewComponent
    {
        public StudentViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
