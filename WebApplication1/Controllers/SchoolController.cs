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
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAll()
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
        //[ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> Get(string id)
        {

            try
            {
                var student = await _studentService.GetByIdAsync(id);

                if(student == null) { return NotFound(); }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        // POST api/<SchoolController>string value
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentDTO studentDTO)
        {

            try
            {                    
                    await _studentService.CreateAsync(new Student
                    {
                        Id = studentDTO.Id,
                        Name = studentDTO.Name,
                        Age = studentDTO.Age
                    });

                return CreatedAtAction(nameof(Student), studentDTO);
                
                
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }

        // PUT api/<SchoolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] StudentDTO studentDTO)
        {
            try
            {
                
                if (id != studentDTO.Id) { return BadRequest("Error on ID"); }               

                await _studentService.UpdateAsync(id, new Student
                {
                    Id = id,
                    Name = studentDTO.Name,
                    Age = studentDTO.Age
                });

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
