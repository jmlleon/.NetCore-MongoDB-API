
using Domain_Layer.Model;

namespace Domain_Layer.Interfaces.Services
{
    public interface IStudentService
    {

        Task<IEnumerable<Student>> GetAsync();

        Task<Student?> GetByIdAsync(string id);

        Task CreateAsync(Student student);

        Task UpdateAsync(string id, Student student);

        Task RemoveAsync(string id);

    }
}
