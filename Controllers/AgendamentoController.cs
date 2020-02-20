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

        public Boolean verificaDisponibilidade(int salaId, DateTime horainicio, DateTime horafim)
        {
            var conflito = _context.Agendamentos
                .Include(x => x.Sala)
                .Where(x => x.SalaId == salaId && (
                    (horainicio >= x.HoraInicio.Date && horainicio <= x.HoraFim.Date) ||
                    (horafim >= x.HoraInicio.Date && horafim <= x.HoraFim.Date) ||
                    (horainicio <= x.HoraInicio.Date && horafim >= x.HoraFim.Date)
                ))
                .AsNoTracking()
                .Count();

            return conflito == 0 ? true : false;
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
            if (verificaDisponibilidade(model.SalaId, model.HoraInicio, model.HoraFim) == false)
            {
                return new ResultViewModel
                {
                    Success = true,
                    Message = "Tente outro horario e/ou outra sala",
                    Data = "Infelizmente essa sala já está agendada nesse horario"
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
            if (verificaDisponibilidade(model.SalaId, model.HoraInicio, model.HoraFim) == false)
            {
                return new ResultViewModel
                {
                    Success = true,
                    Message = "Tente outro horário",
                    Data = "Infelizmente esse horário já está ocupado"
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