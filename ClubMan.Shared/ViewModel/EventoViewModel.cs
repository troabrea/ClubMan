using ClubMan.Shared.Model;

namespace ClubMan.Shared.ViewModel;

public class EventoViewModel
{
    public long Id { get; set; }
    public EventoDeSocio Evento { get; set; }
    public Instalacion Instalacion { get; set; }
    public Localidad Localidad { get; set; }
    public Socio Socio { get; set; }
    
    public DateTime StartTime => Evento.FechaHora;
    public DateTime EndTime => Evento.FechaHora.AddHours(Evento.Horas);
}