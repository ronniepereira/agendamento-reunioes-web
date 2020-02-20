using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendamentoReunioesApp.Data;
using AgendamentoReunioesApp.Models;

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
        [ResponseCache(Duration = 3600)]
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

        [HttpPut]
        [Route("v1/salas")]
        public Sala Put([FromBody]Sala sala)
        {
            _context.Entry<Sala>(sala).State = EntityState.Modified;
            _context.SaveChanges();

            return sala;
        }

        [Route("v1/salas")]
        [HttpDelete]
        public Sala Delete([FromBody]int id)
        {
            var sala = _context.Salas.Find(id);
            _context.Salas.Remove(sala);
            _context.SaveChanges();

            return sala;
        }
    }
}
