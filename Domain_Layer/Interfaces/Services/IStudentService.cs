
using Domain_Layer.Model;

namespace Domain_Layer.Interfaces.Services
{
    public interface IStudentService
    {

        Task<IEnumerable<Student>> GetAsync();

        Task<Student?> GetByIdAsync(string id);

        Task <Student>CreateAsync(Student student);

        Task UpdateAsync(string id, Student student);

        Task<int> RemoveAsync(string id);

    }
}
