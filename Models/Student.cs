using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVCWithRazor.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }
        [ValidateNever]
        public Department Department { get; set; }
    }
}
