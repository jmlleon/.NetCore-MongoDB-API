
using Domain_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAsync();

        Task<Student?> GetByIdAsync(string id);

        Task<Student> CreateAsync(Student student);

        Task UpdateAsync(string id, Student student);

        Task<int> RemoveAsync(string id);


    }
}
