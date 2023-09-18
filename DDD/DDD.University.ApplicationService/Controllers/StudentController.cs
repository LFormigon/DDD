using DDD.Infra.MemoryDb.Interfaces;
using DDD.Infra.MemoryDb.Repositories;
using DDD.Unimar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.University.ApplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get() 
        {
            try
            {
                return Ok(_studentRepository.GetStudents());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar os alunos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id) 
        {
            try
            {
                var student = _studentRepository.GetStudent(id);
                if (student == null)
                {
                    return NotFound("Estudante não encontrado.");
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar o aluno: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student) 
        {
            try
            {
                if (student.FirstName.Length < 3 || student.FirstName.Length > 30)
                {
                    return BadRequest("Nome não pode ser menor que 3 ou maior que 40");
                }

                _studentRepository.InsertStudent(student);
                return CreatedAtAction(nameof(GetById), new { Id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao inserir um aluno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, Student updatedStudent)
        {
            try
            {
                var student= _studentRepository.GetStudent(id);

                if (student == null)
                {
                    return NotFound("Não foi encontrada nenhum aluno.");
                }
                else
                {
                    student.FirstName = updatedStudent.FirstName;
                    student.LastName = updatedStudent.LastName;
                    student.Email = updatedStudent.Email;
                    student.IsActive = updatedStudent.IsActive;

                    _studentRepository.UpdateStudent(student);

                    return Ok("Aluno atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar o aluno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                var student = _studentRepository.GetStudent(id);

                if (student == null)
                {
                    return NotFound("Não foi encontrada nenhum aluno.");
                }

                _studentRepository.DeleteStudent(student);

                return Ok("Aluno deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao deletar o aluno: {ex.Message}");
            }
        }
    }
}
