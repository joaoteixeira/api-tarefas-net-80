using ApiTarefasNet80.DTOs;
using ApiTarefasNet80.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefasNet80.Controllers
{
    [Route("tarefas")]
    [ApiController]
    public class TarefaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Tarefa> listaTarefas = new TarefaDAO().List();

                return Ok(listaTarefas);
            }
            catch (Exception)
            {
                return Problem($"Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var tarefa = new TarefaDAO().GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                return Ok(tarefa);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TarefaDTO item)
        {
            var tarefa = new Tarefa();

            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;
            tarefa.Data = DateTime.Now;

            try
            {
                var dao = new TarefaDAO();
                tarefa.Id = dao.Insert(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Created("", tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TarefaDTO item)
        {
            try
            {
                var tarefa = new TarefaDAO().GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                tarefa.Descricao = item.Descricao;
                tarefa.Feito = item.Feito;

                new TarefaDAO().Update(tarefa);

                return Ok(tarefa);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var tarefa = new TarefaDAO().GetById(id);

                if (tarefa == null)
                {
                    return NotFound();
                }

                new TarefaDAO().Delete(tarefa.Id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
