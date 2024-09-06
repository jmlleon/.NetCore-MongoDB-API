using Application_Layer.Services;
using Domain_Layer.DTO;
using Domain_Layer.Interfaces.Repositories;
using Domain_Layer.Interfaces.Services;
using Domain_Layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Controllers;
using Moq;
using System.Net;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public async Task TestMethodService()
        {          
            //Arrange
            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.GetByIdAsync("6684133c18929ad45acc8988")).ReturnsAsync(new Student { Id = "6684133c18929ad45acc8988", Name="Juan Miguel Lorenzo", Age=34});
           
            //Act
            StudentService studentService = new (mockRepository.Object);
            var student =await  studentService.GetByIdAsync("6684133c18929ad45acc8988");

            //Assert
            Assert.IsNotNull(student);
            Assert.AreEqual("Juan Miguel Lorenzo", student?.Name);         
          

        }

        [TestMethod]
        public async Task TestMethodController(){

            //Arrange
            var mockRepo = new Mock<IStudentService>();
            IEnumerable<Student> studentList = new List<Student> { new() {Id= "6684133c18929ad45acc8988",Name="John Michael Stone", Age=34}, new() { Id = "6684133c18929ad45acc8989'", Name = "Pedro Luis Gonzalez", Age = 33}};
            mockRepo.Setup(repo => repo.GetAsync()).ReturnsAsync(studentList);
            var schoolController = new SchoolController(mockRepo.Object);
            
            //Act

            var result=await schoolController.GetAll();
            var resultContent= result.Result as OkObjectResult;

            //Assert HttpStatusCode.OK
            Assert.IsNotNull(resultContent?.Value);
            Assert.AreEqual((int)HttpStatusCode.OK, resultContent.StatusCode);          
                    


        }

       
    }
}