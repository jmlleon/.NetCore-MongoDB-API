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

        public async Task<Student> CreateAsync(Student student) {

            //Check Not repeat Name and Age

            var studentList= await GetAsync();

            var studentsToSearch=studentList.Where(s=>s.Name==student.Name && s.Age==student.Age).ToList();

            if (studentsToSearch.Count > 0) {

                throw new Exception("There is a student with same name and age");
            
            }

           var result= await _studentRepository.CreateAsync(student);

            return result;

        }

        public async Task UpdateAsync(string id, Student student) => await _studentRepository.UpdateAsync(id, student);

        public async Task<int> RemoveAsync(string id) {
                        
            return await _studentRepository.RemoveAsync(id);
        
        }
    }
}
