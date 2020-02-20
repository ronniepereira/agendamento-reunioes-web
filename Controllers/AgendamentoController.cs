using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendamentoReunioesApp.Data;
using AgendamentoReunioesApp.Models;
using AgendamentoReunioesApp.ViewModels;
using AgendamentoReunioesApp.ViewModels.AgendamentoViewModels;

namespace AgendamentoReunioesApp.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly StoreDataContext _context;

        public AgendamentoController(StoreDataContext context)
        {
            _context = context;
        }

        private Agendamento verificaDisponibilidade(int salaId, DateTime horaInicio, DateTime horaFim, int agendamentoId = 0)
        {
            return _context.Agendamentos
                .Include(x => x.Sala)
                .Where(x =>
                    x.SalaId == salaId
                    && (
                        (horaInicio >= x.HoraInicio.Date && horaInicio <= x.HoraFim.Date) ||
                        (horaFim >= x.HoraInicio.Date && horaFim <= x.HoraFim.Date) ||
                        (horaInicio <= x.HoraInicio.Date && horaFim >= x.HoraFim.Date)
                    )
                    &&
                    x.Id != agendamentoId)
                .AsNoTracking()
                .FirstOrDefault();
        }

        [Route("v1/agendamentos")]
        [HttpGet]
        public IEnumerable<ListAgendamentoViewModel> Get()
        {
            return _context.Agendamentos
                .Include(x => x.Sala)
                .Select(x => new ListAgendamentoViewModel
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    HoraInicio = x.HoraInicio,
                    HoraFim = x.HoraFim,
                    SalaId = x.SalaId,
                    Sala = x.Sala.Nome
                })
                .AsNoTracking()
                .ToList();
        }

        [Route("v1/agendamentos/{id}")]
        [HttpGet]
        public Agendamento Get(int id)
        {
            return _context.Agendamentos
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefault();
        }

        [Route("v1/agendamentos")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorAgendamentoViewModel model)
        {
            // Validação minima
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível realizar o agendamento",
                    Data = model.Notifications
                };
            }

            // Verifica disponibilidade do horario da sala
            var conflito = verificaDisponibilidade(model.SalaId, model.HoraInicio, model.HoraFim);
            if (conflito != null)
            {
                return new ResultViewModel
                {
                    Success = true,
                    Message = "Conflito de horário detectado",
                    Data = new
                    {
                        HoraInicio = conflito.HoraInicio,
                        HoraFim = conflito.HoraFim
                    }
                };
            }

            var agendamento = new Agendamento();
            agendamento.Titulo = model.Titulo;
            agendamento.HoraInicio = model.HoraInicio;
            agendamento.HoraFim = model.HoraFim;
            agendamento.DataCriacao = DateTime.Now;
            agendamento.SalaId = model.SalaId;

            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Agendamento realizado com sucesso!",
                Data = agendamento
            };
        }

        [Route("v1/agendamentos")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorAgendamentoViewModel model)
        {
            // Validação minima
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o agendamento",
                    Data = model.Notifications
                };
            }

            // Verifica disponibilidade do horario da sala
            var conflito = verificaDisponibilidade(model.SalaId, model.HoraInicio, model.HoraFim, model.Id);
            if (conflito == null)
            {
                return new ResultViewModel
                {
                    Success = true,
                    Message = "Conflito de horário detectado",
                    Data = new
                    {
                        HoraInicio = conflito.HoraInicio,
                        HoraFim = conflito.HoraFim
                    }
                };
            }

            var agendamento = _context.Agendamentos.Find(model.Id);
            agendamento.Titulo = model.Titulo;
            agendamento.HoraInicio = model.HoraInicio;
            agendamento.HoraFim = model.HoraFim;
            agendamento.DataCriacao = DateTime.Now;
            agendamento.SalaId = model.SalaId;

            _context.Entry<Agendamento>(agendamento).State = EntityState.Modified;
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Agendamento atualizado com sucesso!",
                Data = agendamento
            };
        }

        [Route("v1/agendamentos")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]int id)
        {
            var agendamento = _context.Agendamentos.Find(id);
            _context.Agendamentos.Remove(agendamento);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Agendamento atualizado com sucesso!",
                Data = agendamento
            };
        }

    }
}