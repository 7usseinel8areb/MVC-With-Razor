using MVCWithRazor.Models;

namespace MVCWithRazor.Interfaces
{
    public interface IDepartment
    {
        Task<List<Department>> GetAll();
    }
}
