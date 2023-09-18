using DDD.Infra.MemoryDb.Interfaces;
using DDD.Infra.MemoryDb.Repositories;
using DDD.Unimar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.University.ApplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        readonly IDisciplineRepository _disciplineRepository;

        public DisciplineController(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        [HttpGet]
        public ActionResult<List<Discipline>> Get()
        {
            try
            {
                return Ok(_disciplineRepository.GetDisciplines());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar disciplinas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Discipline> GetById(int id)
        {
            try
            {
                var discipline = _disciplineRepository.GetDiscipline(id);
                if (discipline == null)
                {
                    return NotFound("Não foi encontrada nenhuma disciplina com o ID fornecido.");
                }

                return Ok(discipline);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar a disciplina: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Student> CreateDiscipline(Discipline discipline)
        {
            try
            {
                _disciplineRepository.InsertDiscipline(discipline);
                return CreatedAtAction(nameof(GetById), new { Id = discipline.Id }, discipline);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao criar a disciplina: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDiscipline(int id, Discipline updatedDiscipline)
        {
            try
            {
                var existingDiscipline = _disciplineRepository.GetDiscipline(id);

                if (existingDiscipline == null)
                {
                    return NotFound("Não foi encontrada nenhuma disciplina.");
                }
                else
                {
                    existingDiscipline.Name = updatedDiscipline.Name;
                    existingDiscipline.Value = updatedDiscipline.Value;
                    existingDiscipline.IsAvailable = updatedDiscipline.IsAvailable;
                    existingDiscipline.EAD = updatedDiscipline.EAD;

                    _disciplineRepository.UpdateDiscipline(existingDiscipline);

                    return Ok("Disciplina atualizada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar a disciplina: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDiscipline(int id)
        {
            try
            {
                var existingDiscipline = _disciplineRepository.GetDiscipline(id);

                if (existingDiscipline == null)
                {
                    return NotFound("Não foi encontrada nenhuma disciplina.");
                }

                _disciplineRepository.DeleteDiscipline(existingDiscipline);

                return Ok("Disciplina deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao deletar a disciplina: {ex.Message}");
            }
        }
    }
}
