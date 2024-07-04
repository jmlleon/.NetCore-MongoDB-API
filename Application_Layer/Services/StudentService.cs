using Domain_Layer.Interfaces.Repositories;
using Domain_Layer.Interfaces.Services;
using Domain_Layer.Model;


namespace Application_Layer.Services
{ 

    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;             
        }

        public async Task<IEnumerable<Student>> GetAsync() =>await _studentRepository.GetAsync();

        public async Task<Student?> GetByIdAsync(string id) => await _studentRepository.GetByIdAsync(id);

        public async Task CreateAsync(Student student) => await _studentRepository.CreateAsync(student);

        public async Task UpdateAsync(string id, Student student) => await _studentRepository.UpdateAsync(id, student);

        public async Task RemoveAsync(string id) => await _studentRepository.RemoveAsync(id);
    }
}
