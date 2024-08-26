using Microsoft.AspNetCore.Mvc;
using School.Infra.Repositories;
using School.Model.Dtos;
using School.Model.Entities;

namespace School.API.Controllers
{
    [ApiController]
    [Route("student/")]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _repository;

        public StudentController(StudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _repository.GetAll<Student>();

            return new OkObjectResult(students.Select(x => new StudentDto(x)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var student = await _repository.GetEntityBy<Student>(x => x.Id == id);

            if (student == null)
                return new NotFoundObjectResult(Student_NotFound);

            return new OkObjectResult(new StudentDto(student));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDto studentCreateDto)
        {
            var student = new Student(studentCreateDto);

            await _repository.Add(student);

            return new OkResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentUpdateDto studentUpdateDto)
        {
            var student = await _repository.GetEntityBy<Student>(x => x.Id == id);

            if (student == null)
                return new NotFoundObjectResult(Student_NotFound);

            if (studentUpdateDto.Name != null)
                student.UpdateName(studentUpdateDto.Name);

            if (studentUpdateDto.Email != null)
                student.UpdateEmail(studentUpdateDto.Email);

            if (studentUpdateDto.Address != null)
                student.UpdateAddress(studentUpdateDto.Address);

            await _repository.Update<Student>(student);

            return new OkResult();
        }

        [HttpDelete("inactivate/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _repository.GetEntityBy<Student>(x => x.Id == id);

            if (student == null)
                return new NotFoundObjectResult(Student_NotFound);

            student.InactiveStudent();
            await _repository.Update<Student>(student);

            return new OkResult();
        }

        private const string Student_NotFound = "Estudante não encontrado";
    }
}
