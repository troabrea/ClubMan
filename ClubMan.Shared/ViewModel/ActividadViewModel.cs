using ClubMan.Shared.Model;

namespace ClubMan.Shared.ViewModel;

public class ActividadViewModel
{
    public Guid Id { get; set; }
    public Actividad Actividad { get; set; }
    public Instalacion Instalacion { get; set; }
    public Localidad Localidad { get; set; }

    public DateTime StartTime => Actividad.FechaHora;
    public DateTime EndTime => Actividad.FechaHora.AddHours(Actividad.Horas);
}