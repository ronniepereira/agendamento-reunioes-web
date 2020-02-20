using System;
using Flunt.Validations;
using Flunt.Notifications;

namespace AgendamentoReunioesApp.ViewModels.AgendamentoViewModels
{
    public class EditorAgendamentoViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int SalaId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Titulo, 120, "Titulo", "O título deve conter até 120 caracteres")
                    .HasMinLen(Titulo, 3, "Titulo", "O titulo deve conter pelo menos 3 caracteres")
                    .IsGreaterThan(HoraFim, HoraInicio, "HoraFim", "A hora fim deve ser maior que hora de inicio")
            );
        }
    }
}