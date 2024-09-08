using Domain_Layer.Interfaces.Repositories;
using Domain_Layer.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Infraestructure_Layer.Repositories
{


    public class StudentRepository:IStudentRepository
    {               

        private readonly IMongoCollection<Student> _studentCollection;

        public StudentRepository(IOptions<SchoolDBSettings> schoolDBSettings)
        {
            var mongoClient = new MongoClient(schoolDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(schoolDBSettings.Value.DatabaseName);
            _studentCollection = mongoDatabase.GetCollection<Student>(schoolDBSettings.Value.StudentsCollectionName);
        }

        public async Task<IEnumerable<Student>> GetAsync() => await _studentCollection.Find(_ => true).ToListAsync();

        public async Task<Student?> GetByIdAsync(string id) => await _studentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Student> CreateAsync(Student student) {
            
            await _studentCollection.InsertOneAsync(student); 

            return await _studentCollection.Find(s=>s.Name == student.Name && s.Age==student.Age).FirstOrDefaultAsync();  


        }

        public async Task UpdateAsync(string id, Student student) => await _studentCollection.ReplaceOneAsync(x => x.Id == id, student);

        public async Task<int> RemoveAsync(string id) {
            
          DeleteResult result=  await _studentCollection.DeleteOneAsync(x => x.Id == id);
          return result.DeletedCount.Equals(0)?0:1;

        
        }

    }

    
}
