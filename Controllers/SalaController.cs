using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendamentoReunioesApp.Data;
using AgendamentoReunioesApp.Models;
using AgendamentoReunioesApp.ViewModels;

namespace AgendamentoReunioesApp.Controllers
{
    public class SalaController : Controller
    {
        private readonly StoreDataContext _context;

        public SalaController(StoreDataContext context)
        {
            _context = context;
        }

        [Route("v1/salas")]
        [HttpGet]
        public IEnumerable<Sala> Get()
        {
            return _context.Salas.AsNoTracking().ToList();
        }

        [Route("v1/salas/{id}")]
        [HttpGet]
        public Sala Get(int id)
        {
            //Find ainda não suporta AsNoTracking() -- VERIFICAR ATUALMENTE
            return _context.Salas.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/salas/{id}/agendamentos")]
        [HttpGet]
        public IEnumerable<Agendamento> GetAgendamentos(int id)
        {
            return _context.Agendamentos.AsNoTracking().Where(x => x.SalaId == id).ToList();
        }

        [Route("v1/salas")]
        [HttpPost]
        public Sala Post([FromBody]Sala sala)
        {
            _context.Salas.Add(sala);
            _context.SaveChanges();

            return sala;
        }

        [Route("v1/salas")]
        [HttpPut]
        public Sala Put([FromBody]Sala sala)
        {
            _context.Entry<Sala>(sala).State = EntityState.Modified;
            _context.SaveChanges();

            return sala;
        }

        [Route("v1/salas/{id:int}")]
        [HttpDelete]
        public ResultViewModel Delete(int id)
        {
            var sala_find = _context.Salas.Find(id);
            _context.Salas.Remove(sala_find);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Sala deletado com sucesso!",
                Data = "Sala deletado"
            };
        }
    }
}
