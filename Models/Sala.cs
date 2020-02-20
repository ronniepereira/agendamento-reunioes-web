using System;
using System.Collections.Generic;

namespace AgendamentoReunioesApp.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Agendamento> Agendamentos { get; set; }
    }
}