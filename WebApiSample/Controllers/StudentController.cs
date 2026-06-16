using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;
using WebApiSample.Models.Repository;
using WebApiSample.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // احراز هویت برای همه اکشن‌ها
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/<MessagesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _studentRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("public")]
        [AllowAnonymous] // این متد نیازی به توکن ندارد
        public IActionResult PublicEndpoint()
        {
            return Ok(new { message = "This is public - no token needed!" });
        }



        /// <summary>
        /// دریافت جزئیات
        /// </summary>
        /// <param name="id">آیدی دانش آموز</param>
        /// <returns></returns>
        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _studentRepository.Get(id);
            return Ok(result);
        }

        // POST api/<MessagesController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentViewModel model)
        {
            var result = _studentRepository.Add(model);
            var url = Url.Action(nameof(Get),"Student",new {id=result.Id},Request.Scheme);
            return Created(url, result);
        }

        // PUT api/<MessagesController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] Student student)
        {
           var result =  _studentRepository.Update(student);
            return Ok(result);
        }

        /// <summary>
        /// حذف
        /// </summary>
        /// <param name="id">شماره دانش آموز</param>
        /// <returns></returns>
        // DELETE api/<MessagesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _studentRepository.Delete(id);
            return Ok(result);
        }
    }
}
