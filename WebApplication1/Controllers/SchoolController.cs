using Domain_Layer.DTO;
using Domain_Layer.Interfaces.Services;
using Domain_Layer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {       

        private readonly IStudentService _studentService;
       // private readonly ILogger<SchoolController> _logger;


        public SchoolController(IStudentService studentService) {

            _studentService = studentService;


        }

        // GET: api/<SchoolController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> Get()
        {

            try
            {
                var studentsList =await _studentService.GetAsync();

                return Ok(studentsList);
            }
            catch (Exception ex)
            {

                return  BadRequest($"{ex.Message}");  
            }       
           
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> Get(string id)
        {

            try
            {
                var student = await _studentService.GetByIdAsync(id);

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        // POST api/<SchoolController>string value
        [HttpPost]
        public async Task<ActionResult> Post( [FromBody] StudentDTO studentDTO)
        {

            try
            {
                Student student = new Student();

                await _studentService.CreateAsync(student);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }

        // PUT api/<SchoolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] string value)
        {
            try
            {
                //Check for equal value id and value

                Student student = new Student
                {
                    Id = id,
                    Name = value,
                    Age = 0
                };

                await _studentService.UpdateAsync(id, student);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {                
                await _studentService.RemoveAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }
    }
}
