using System;

namespace AgendamentoReunioesApp.ViewModels.AgendamentoViewModels
{
    public class ListAgendamentoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int SalaId { get; set; }
        public string Sala { get; set; }
    }
}