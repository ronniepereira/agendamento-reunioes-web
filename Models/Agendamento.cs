using System;

namespace AgendamentoReunioesApp.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public DateTime DataCriacao { get; set; }
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
    }
}